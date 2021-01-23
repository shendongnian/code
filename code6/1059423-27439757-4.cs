    public class ScreensFactory
    {
        public List<ScreenBoundsWrapper> GetAllScreens()
        {
            return Screen.AllScreens
                .Select(s => new ScreenBoundsWrapper(s))
                .ToList();
        }
    } 
