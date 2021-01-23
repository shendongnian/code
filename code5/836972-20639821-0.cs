    public class HeatMap
    {
       public int Width { get; set; }
       public int Height { get; set; }
    }
    
    public class HeatMapComponent
    {
        private HeatMap myHeatMap; // Must have a reference to the object you want to change!
    
        public void SomeMethod()
        {
            myHeatMap.Width = 10;
        }
    }
