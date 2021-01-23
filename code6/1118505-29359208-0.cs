    public interface ISampleRepository { }
    public class SampleRepository : ISampleRepository { }
    
    public class HomeController : Controller
    {
        private ISampleRepository myRepository;
    
        public HomeController()
        {
            myRepository = new SampleRepository();
        }
    }
