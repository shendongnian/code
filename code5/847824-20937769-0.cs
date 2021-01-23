        public class ModuleBMainWindowViewModel : Screen , INotifyPropertyChanged
    {
        public ModuleBMainWindowViewModel()
        {
            _myBrushProperty = new SolidColorBrush(Colors.White);
            DisplayName = "ModuleB";
            CalcMyBrush();
           
        }
        private SolidColorBrush _myBrushProperty;
        public SolidColorBrush MyBrushProperty
        {
            get
            {
                return _myBrushProperty;
            }
            set
            {
                _myBrushProperty = value;
            }
        }
        private void CalcMyBrush()
        {
             Task.Run(() =>
            {
                //DoSomething that changes _myBrushProperty and takes some time and needs to run async and after that sets
                _myBrushProperty = new SolidColorBrush(Colors.Blue);
            });
             NotifyOfPropertyChange("MyBrushProperty");
        }
    }
