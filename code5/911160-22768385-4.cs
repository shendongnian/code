    public interface IConfiguration
    {
        public Image AvailablePic { get; }
        public Image UnavailablePic { get; }
    }
    
    public class Configuration : IConfiguration
    {
        public Configuration(Image availablePic, Image unavailablePic)
        {
            AvailablePic = availablePic;
            UnavailablePic = unavailablePic;
        }
    
        public Image AvailablePic { get; private set; }
        public Image UnavailablePic { get; private set; }
    }
