    using System.Windows; 
        using System.Windows.Input; 
        using System.Windows.Threading; 
     
        using Cimbalino.Phone.Toolkit.Services; 
     
        using GalaSoft.MvvmLight.Command; 
        using GalaSoft.MvvmLight; 
        /// <summary> 
        /// This class contains properties that the main View can data bind to. 
        /// </summary> 
        public class MainViewModel : ViewModelBase 
        { 
            /// <summary> 
            /// The screenshot service 
            /// </summary> 
            private readonly IScreenshotService _screenshotService; 
     
            /// <summary> 
            /// Initializes a new instance of the MainViewModel class. 
            /// </summary> 
            public MainViewModel(IScreenshotService screenshotService) 
            { 
                _screenshotService = screenshotService; 
                TakeScreenshotCommand = new RelayCommand(TakeScreenshot); 
            } 
     
            /// <summary> 
            /// Gets the take screenshot command. 
            /// </summary> 
            /// <value> 
            /// The take screenshot command. 
            /// </value> 
            public ICommand TakeScreenshotCommand { get; private set; } 
     
            /// <summary> 
            /// Calls to. 
            /// </summary> 
            private void TakeScreenshot() 
            { 
                _screenshotService.TakeScreenshot("CimbalinoScreenshot"); 
            } 
        }
