    public class ImagesController : ApiController
    {
        // GET api/images
        public Task<HttpResponseMessage> Get(string id, string path)
        {            
            //do stuff           
            return Task.Factory.StartNew(() =>
            {
               using( stream = new MemoryStream()) //as it's asynchronous we can't use a using statement here!
               {
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = GetPngBitmap(stream)
                    };
                    response.Content.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                    return response;
                }
                //how can I dispose stream???
               }
            });
        }
    }
