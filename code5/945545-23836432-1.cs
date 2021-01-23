        public override void OnException(HttpActionExecutedContext context)
            {
                if (context.Exception is NotImplementedException)
                {
                    context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                    // Append Header here.
                    context.Response.Headers.Add("X-SOME-HEADER", header);
                }
            }
