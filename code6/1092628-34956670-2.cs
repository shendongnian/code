        public async Task<HttpResponseMessage> Get(string model, string version)
        {
            try
            {
                // code that get vm removed
                var blobref = HttpUtility.UrlDecode(Path.GetFileName(vm.Url)) ;
                var container = Path.GetFileName(Path.GetDirectoryName(vm.Url));
                HttpContext.Current.Response.Buffer = false;    // turn off buffering
                HttpContext.Current.Response.BufferOutput = false;
                //var ret = await Task.Run(() => _blobService.FetchBlob(blobref, container));
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                resp.Headers.TransferEncodingChunked = true;
                //resp.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(ret));
                var stream = await Task.Run(() => _blobService.FetchBlobToStream(blobref, container));
                stream.Position = 0;
                resp.Content = new ChunkedStreamContent(stream);
                return resp;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                var errmsg = "FirmwareUpdateController - Get - Error: " + ((ex.InnerException == null)
                    ? ex.Message
                    : ex.Message + " Inner Exception " + ex.InnerException.Message);
                _logger.Error(errmsg);
                resp.Content = new StringContent(errmsg);
                return resp;
            }
        }
    public class ChunkedStreamContent : StreamContent
    {
        public ChunkedStreamContent(Stream stream)
            : base(stream, 1200) { }
        protected override bool TryComputeLength(out long length)
        {
            length = 0L;
            return false;
        }
    }
