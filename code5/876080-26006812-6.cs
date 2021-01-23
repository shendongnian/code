    public class PostParms
    {
        public string ExtraInfo { get; set; }
    }
    public class MediaController : ApiController
    {
        [HttpPost]// byte[] is sent in body and parms sent in url
        public string Post([FromBody] byte[] audioSource, PostParms parms)
        {
            byte[] bytes = audioSource;
            return "success";
        }
    }
