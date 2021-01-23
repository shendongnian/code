    public class ValuesController : ApiController
    {        
        public string Get()
        {
            var sb = new StringBuilder();
            foreach (var item in RequestQueue.Queue)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
        public void Post(int id)
        {
            RequestQueue.Queue.Enqueue(id);
        }        
    }
