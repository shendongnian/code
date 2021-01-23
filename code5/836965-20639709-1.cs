        public class HeatMapComponent
        {
        HeatMap _map;
        public HeatMapComponent()
        {
         _map = new HeatMap();
        }
        public void SomeMethod()
        {
        _map.Width = 10; //should work if Width is public and not readonly and if _map was initialized already, ie not null
        }
        }
