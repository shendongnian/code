    public class MySlider : Slider
    {
        public MySlider()
        {
            this.Minimum = 1;
            this.Maximum = 1000;
        }
    }
    
    public MainClass
    {
      public MainClass()
      {
        MySlider slider = new MySlider() { Width = 400, Name = "TheSlider"};
        var sliderViewModel = new SliderViewModel();
        slider.DataContext = sliderViewModel;
        var logScaleConverter = new LogScaleConverter();
        //You can either put this in a binding or if you hard code the value then just do this
        slider.Value = logScaleConverter.Convert(10); //This is where you pass your linear like 1,2,10,1000 for instance. You probably want to use this method on how you set the Value property of the slider. Use the logScaleConverter.Convert(10); for example.
      }
    }
    public class SliderViewModel : INotifyOfPropertyChanged
    {
      private double _sliderValue;
      public double SliderValue {
        get
        {
          return _sliderValue;
        }
        set
        {
           _sliderValue = new LogScaleConverter().Convert(value);
           NotifyOfPropertyChanged("SliderValue");
        }
      }
      event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
      {
        add { /* Do nothing */ }
        remove { /* Do nothing */ }
      }
    }
