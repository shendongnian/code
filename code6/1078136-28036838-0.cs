    public class FindStuffController : ApiController
    {
        [Route("stuff/{emailAddress}")]
        [HttpGet]
        public string FindStuffByDates(string emailAddress, string start, string end)
        {
            return "start = " + start + " end = " + end;
        }
        [Route("stuff/{emailAddress}/{stuffId}")]
        [HttpGet]
        public object FindStuffById(string emailAddress, string stuffId)
        {
            return "byId = " + stuffId;
        }
    }
