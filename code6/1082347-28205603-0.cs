        /// <summary>
        /// Fake HTTPCONTEXT generator
        /// </summary>
        /// <param name="extention">Http context extention</param>
        /// <param name="domain">Http context domain</param>
        /// <param name="locale">Http context locale</param>
        /// <returns>Fake Http Context</returns>
        private static HttpContext FakeHttpContext(string extention, string domain, string locale = "en-US,en;q=0.8")
        {
            HttpWorkerRequest httpWorkerRequest = new SimpleWorkerRequestHelper(false, domain, extention, locale);
            return new HttpContext(httpWorkerRequest);
        }
