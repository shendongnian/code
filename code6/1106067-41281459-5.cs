    public class ViewModelFirstNavigationService
        {
            private Dictionary<Type, Uri> _registeredViews;
            private Dictionary<Type, Func<NavigableViewModel>> _registeredViewModels;
            private List<string> _allXamlPages;
            private MainViewModel _mainContainerViewModel;
            public NavigableViewModel CurrentViewModel;
    
            public ViewModelFirstNavigationService(MainViewModel mainContainerViewModel)
            {
                _mainContainerViewModel = mainContainerViewModel;
                _registeredViews = new Dictionary<Type, Uri>();
                _registeredViewModels = new Dictionary<Type, Func<NavigableViewModel>>();
                _allXamlPages = GetAllXamlPages();
            }
    
            private List<string> GetAllXamlPages()
            {
                // this part is a bit tricky. We use it to find all xaml pages in the current project.
                // so you need to be sure that all your pages you want to use with your viewmodles need to end with page.xaml
                // Example : LoginPage.xaml will work fine. Parameters.xaml won't.
                System.Reflection.Assembly viewModelFirstProjectAssembly;
                viewModelFirstProjectAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                var stream = viewModelFirstProjectAssembly.GetManifestResourceStream(viewModelFirstProjectAssembly.GetName().Name + ".g.resources");
                var resourceReader = new ResourceReader(stream);
                List<string> pages = new List<string>();
                foreach (DictionaryEntry resource in resourceReader)
                {
                    Console.WriteLine(resource.Key);
                    string s = resource.Key.ToString();
                    if (s.Contains("page.baml"))
                    {
                        pages.Add(s.Remove(s.IndexOf(".baml")));
                    }
                }
                return pages;
            }
    
            private Type ResolveViewModelTypeFromSingletonGetterFunc<T>(Func<T> viewModelSingletonGetterFunc)
            {
                MethodInfo methodInfo = viewModelSingletonGetterFunc.Method;
                return methodInfo.ReturnParameter.ParameterType;
            }
    
            private Uri ResolvePageUriFromViewModelType(Type viewModelType)
            {
                string pageName = String.Empty;
                int index = viewModelType.Name.IndexOf("ViewModel");
                pageName = viewModelType.Name.Remove(index);
                string pagePath = String.Format("{0}.xaml", _allXamlPages.Where(page => page.Contains(pageName.ToLower())).FirstOrDefault());
                string cleanedPath = pagePath.Remove(0, "views/".Length); //obviously for this to work you need to have your views in a Views folder at the root of the project. But you are alowed yo reat sub folders in it
                return new Uri(cleanedPath, UriKind.Relative);
            }
    
    
            public void AddNavigableElement(Func<NavigableViewModel> viewModelSingletonGetter)
            {
                //Where the magic happens !
                //If your are wondering why a Func, it's because we want our viewmodels to be instantiated only when we need them via IOC.
                //First we ge the type of our viewmodel to register for the Func.
                Type vmType = ResolveViewModelTypeFromSingletonGetterFunc(viewModelSingletonGetter);
                Uri uriPage = ResolvePageUriFromViewModelType(vmType);
                _registeredViews.Add(vmType, uriPage);
                _registeredViewModels.Add(vmType, viewModelSingletonGetter);
            }
    
            public void NavigateTo<GenericNavigableViewModelType>(object parameter = null)
            {
                Type key = typeof(GenericNavigableViewModelType);
                NavigateTo(key, parameter);
            }
    
            public void NavigateTo(Type key, object parameter = null)
            {
                CurrentViewModel?.OnNavigatingTo(parameter);
                CurrentViewModel = _registeredViewModels[key].Invoke();
                Uri uri = _registeredViews[key];
                ((MainWindow)Application.Current.MainWindow).Frame.Source = uri;
                ((MainWindow)Application.Current.MainWindow).Frame.DataContext = CurrentViewModel;
                CurrentViewModel.OnNavigatedTo(parameter);
               // ManageNavigationStack(key, parameter);
            }
    
        }
