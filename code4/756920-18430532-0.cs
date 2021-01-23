        if(!(context.Response Is JsonResponse))
        {
                context.Response = new TextResponse(JsonConvert.SerializeObject(new { Message = "Resource not found" }, Formatting.Indented))
                {
                    StatusCode = statusCode,
                    ContentType = "application/json"
                };
        }
