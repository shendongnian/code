    public class Locations
    {
        private static string[] _locations = {"", "", "", "", "", ""};
    
        private static int _currentLocation = 0;
    
        public static void Iterate(string data)
        {
            foreach(var item in data.split('/'))
            {
                _locations[_currentLocation++] = item;
            
                if(_currentLocation == 6)
                {
                    //Save Data
                 
                    _currentLocation = 0;
                }
            }
        }
    }
