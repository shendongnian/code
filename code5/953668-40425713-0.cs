    [HttpGet]
        [Authorize]
        [Route("OpenFile/{QRFileId}")]
        public HttpResponseMessage OpenFile(int QRFileId)
        {
            QRFileRepository _repo = new QRFileRepository();
            var QRFile = _repo.GetQRFileById(QRFileId);
            if (QRFile == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            string path = ConfigurationManager.AppSettings["QRFolder"] + + QRFile.QRId + @"\" + QRFile.FileName;
            if (!File.Exists(path))
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            Byte[] bytes = File.ReadAllBytes(path);
            //String file = Convert.ToBase64String(bytes);
            response.Content = new ByteArrayContent(bytes);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentDisposition.FileName = QRFile.FileName;
            return response;
        }
