        protected internal virtual IHttpActionResult NoContent()
        {
            HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.NoContent) {Content = new StringContent(string.Empty, Encoding.UTF8)};
            return this.ResponseMessage(responseMsg);
        }
