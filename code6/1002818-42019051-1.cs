    public class RequestLoggingMiddleware
    {
        ...
        private void LogResponse(IOwinContext owinContext)
        {
            var message = new StringBuilder()
                .AppendLine($"{owinContext.Response.StatusCode}")
                .AppendLine(string.Join(Environment.NewLine, owinContext.Response.Headers.Select(x => $"{x.Key}: {string.Join("; ", x.Value)}")));
    
            if (owinContext.Environment.ContainsKey("log-responseBody"))
            {
                var responseBody = (string)owinContext.Environment["log-responseBody"];
                message.AppendLine()
                    .AppendLine(responseBody);
            }
    
            var logEvent = new LogEventInfo
            {
                Level = LogLevel.Trace,
                Properties =
                {
                    {"correlationId", owinContext.Environment["correlation-id"]},
                    {"entryType", "Response"}
                },
                Message = message.ToString()
            };
    
            _logger.Log(logEvent);
        }
    }
