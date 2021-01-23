    public class Class1
    {
        public ImageMap map = null;
        public Class1(Form1 f)
        {
            map = new ImageMap();
    
            map.RegionClick += f.RegionMap_Clicked;
        }
    }
