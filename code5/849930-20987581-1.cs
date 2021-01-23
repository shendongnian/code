        public interface IDialogService
        {
            BaseViewModel ShowTitleDialog(BaseViewModel viewModel, UserControl view, string windowTitle);
        }
        
        public class DialogService : IDialogService
        {
            public BaseViewModel ShowTitleDialog(BaseViewModel viewModel, UserControl view, string windowTitle)
            {
                if (view == null && viewModel == null)
                {
                    throw new ArgumentNullException("view is null");
                }
        
                RegisterTemplate(viewModel.GetType(), view.GetType());
                return ShowTitleDialog(viewModel, windowTitle);
            }
        	private void RegisterTemplate(Type viewModelType, Type viewType)
            {
                const string xamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}}\"><v:{1} /></DataTemplate>";
                var xaml = String.Format(System.Globalization.CultureInfo.InvariantCulture, xamlTemplate, viewModelType.Name, viewType.Name, viewModelType.Namespace, viewType.Namespace);
        
                var context = new ParserContext();
        
                context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
                context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace, viewModelType.Assembly.FullName);
                context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace, viewType.Assembly.FullName);
        
                context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
                context.XmlnsDictionary.Add("vm", "vm");
                context.XmlnsDictionary.Add("v", "v");
        
                var template = (DataTemplate)System.Windows.Markup.XamlReader.Parse(xaml, context);
                var key = template.DataTemplateKey;
                Application.Current.Resources[key] = template;
            }
    
            public BaseViewModel ShowTitleDialog(BaseViewModel viewModel, string windowTitle, bool isEnableScrollBars = false)
            {
                Window window = new Window();
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                ContentControl contentControl = new ContentControl();
                contentControl.Content = viewModel;
    
                if (!isEnableScrollBars)
                {
                    window.Content = contentControl;
                    window.SizeToContent = SizeToContent.WidthAndHeight; window.SizeToContent = SizeToContent.WidthAndHeight;
                }
                else
                {
                    ScrollViewer scrollViewver = new ScrollViewer();
                    scrollViewver.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrollViewver.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrollViewver.Content = contentControl;
                    window.Height = 600;
                    window.MaxHeight = 600;
                    window.Content = scrollViewver;
                }
    
                window.Title = windowTitle;
                window.WindowStyle = WindowStyle.None;
    
                window.Owner = Application.Current.Windows.OfType<System.Windows.Window>().FirstOrDefault(x => x.IsMouseOver);
                window.ShowInTaskbar = false;
                window.ShowDialog();
                return viewModel;
            }
        }
        
