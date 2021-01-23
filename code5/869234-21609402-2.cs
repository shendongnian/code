    public IHttpActionResult GetFileAsync(int fileId)
    {
        // NOTE: If there was any other 'async' stuff here, then you would need to return
        // a Task<IHttpActionResult>, but for this simple case you need not.
        return new FileActionResult(fileId);
    }
    
    public class FileActionResult : IHttpActionResult
    {
        public FileActionResult(int fileId)
        {
            this.FileId = fileId;
        }
    
        public int FileId { get; private set; }
    
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StreamContent(File.OpenRead(@"<base path>" + FileId));
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            // NOTE: Here I am just setting the result on the Task and not really doing any async stuff. 
            // But let's say you do stuff like contacting a File hosting service to get the file, then you would do 'async' stuff here.
            return Task.FromResult(response);
        }
    }
