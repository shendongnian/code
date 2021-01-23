        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.InternalServerError, _respContent);
            switch ((Int32)_respContent.Code)
            { 
                case 1:
                case 6:
                case 7:
                    response = _request.CreateResponse(HttpStatusCode.InternalServerError, _respContent);
                    break;
                case 2:
                case 3:
                case 4:
                    response = _request.CreateResponse(HttpStatusCode.BadRequest, _respContent);
                    break;
            } 
            return Task.FromResult(response);
        }
