    public void ShowFragment(MvxViewModelRequest request, int contentId, Bundle bundle = null, bool addToBackStack = false)
    		{
    			MvxFragment fragment = null;
    
    			IMvxViewsContainer viewContainer = Mvx.Resolve<IMvxViewsContainer>();
    			Type viewType = viewContainer.GetViewType(request.ViewModelType);
    
    			Fragment currentContentFragment = FragmentManager.FindFragmentById(contentId);
    			if (currentContentFragment != null && currentContentFragment.GetType () == viewType && (request.ParameterValues == null || (request.ParameterValues != null && request.ParameterValues.Count == 0))) {
    				drawerLayout.CloseDrawers();
    				return;
    			}
    			fragment = (MvxFragment)Activator.CreateInstance(viewType);
    
    			var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
    			var viewModel = loaderService.LoadViewModel(request, null);
    			fragment.ViewModel = viewModel;
    
    			var contentManager = fragmentManager.BeginTransaction();
    			contentManager.Replace(contentId, fragment);
    			if(addToBackStack)
    				contentManager.AddToBackStack(fragment.GetType().Name);
    			contentManager.Commit();
    		}
