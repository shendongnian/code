    public class ValuesController : ApiController
    {
        [OverrideAuthentication]
        public string Get()
        { ...  }
    }
