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
        var slider = new Slider();
        var logScaleConverter = new LogScaleConverter();
        //You can either put this in a binding or if you hard code the value then just do this
        slider.Value = logScaleConverter.Convert("YOURVALUE");
        slider.Value
      }
    }
