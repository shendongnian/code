    public class ProfileController : ApiController
    {
        [HttpGet]
        public string FullName()
        {
            return "Foo Bar";
        }
        [HttpPost]
        public void FullName(string newName)
        {
            // ...
        }
        [HttpGet]
        public int Age()
        {
            return 22;
        }
        [HttpPost]
        public void Age(int newAge)
        {
            // ...
        }
    }
