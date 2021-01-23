    public class MyViewModel
    {
        private SolidColorBrush _FirstQuadColor;
        public SolidColorBrush FirstQuadColor
        { 
           get { return _FirstQuadColor; }
           set { _FirstQuadColor = value; OnPropertyChanged("FirstQuadColor"); }
        }
    
    private SolidColorBrush _SecondQuadColor;
    public SolidColorBrush SecondQuadColor
    {
       get { return _SecondQuadColor; }
       set { _SecondQuadColor = value; OnPropertyChanged("SecondQuadColor"); }
    }
    
    private SolidColorBrush _ThirdQuadColor;
    public SolidColorBrush ThirdQuadColor
    {
      get { return _ThirdQuadColor; }
      set { _ThirdQuadColor = value; OnPropertyChanged("ThirdQuadColor"); }
    }
    
    private SolidColorBrush _FourthQuadColor;
    public SolidColorBrush FourthQuadColor
    {
       get { return _FourthQuadColor; }
       set { _FourthQuadColor = value; OnPropertyChanged("FourthQuadColor"); }
    }
    
    private ICommand _RectangleButtonClick;
    public ICommand RectangleButtonClick
    {
       get { return _RectangleButtonClick; }
       set { _RectangleButtonClick = value; OnPropertyChanged("RectangleButtonClick"); }
    }
    public MyViewModel()
    {
       RectangleButtonClick = new DelegateCommand(RectangleButtonClick_Execute);
       FirstQuadColor = Brushes.Red;
       SecondQuadColor = Brushes.Green;
       ThirdQuadColor = Brushes.Blue;
       FourthQuadColor = Brushes.Yellow;
    }
        void RectangleButtonClick_Execute()
        {
            var directlyOver = Mouse.DirectlyOver;
            if (directlyOver is Rectangle)
            {
                var selectedRectangle = (directlyOver as Rectangle);
                switch (selectedRectangle.Name)
                {
                    case "FirstQuad" : Console.Write("First Quad clicked"); break;
                    case "SecondQuad": Console.Write("Second Quad clicked"); break;
                    case "ThirdQuad": Console.Write("Third Quad clicked"); break;
                    case "FourthQuad": Console.Write("Fourth Quad clicked"); break;
                }
                
            }
        }
}
