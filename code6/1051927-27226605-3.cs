    public class ValueController : ApiController
    {
        public IEnumerable<string> Get([FromUri]Model my)
                {
                    return new string[] { "value1", "value2" , my.UserId.ToString() };
                }
    }
