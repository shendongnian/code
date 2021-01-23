        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        public async Task<HttpResponseMessage> Inbound()
        {
            var inboundEmail = await InboundEmailExtractor.ExtractInboundEmail(Request);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
