    using WMPLib;
    public partial class MainWindow : Window
    {
        private string _Timecode;
         WindowsMediaPlayerClass _Wmp =  new WindowsMediaPlayerClass{volume = 0};
        public MainWindow()
        {
            InitializeComponent();
            _Wmp.MediaChange += WmpOnMediaChange;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_Timecode);
        }
        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            const string filename = @"C:\Users\Public\Videos\Toto.wmv";
            _Wmp.URL = filename;
        }
        private void WmpOnMediaChange(object item)
        {
            _Wmp.MediaChange -= WmpOnMediaChange;
            _Wmp.controls.pause();
            _Wmp.controls.currentPosition = 0 ;
            _Timecode = ((IWMPControls3) _Wmp.controls).currentPositionTimecode;
            _Wmp.close();
            _Wmp = null;
        }
    }
