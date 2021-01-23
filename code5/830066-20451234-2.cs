    public class MySlider : Slider
    {
        public MySlider()
        {
            Loaded += (s, e) => Value = Maximum;
        }
    }
