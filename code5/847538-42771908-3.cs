    public class JsonResultFilter : IResultFilter
    {
        public const int MaxJsonLengthInBytes = 15728640;    // 15360 k = 15 mb
        public const double AlertPercentage = .95;           // 95%
        // A service that records this warning
        private readonly ISystemWarningService _systemWarningService;
        public JsonResultFilter(ISystemWarningService systemWarningService)
        {
            _systemWarningService = systemWarningService;
        }
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // We're only interested in JsonNetResult
            if (filterContext.Result is JsonNetResult)
            {
                JsonNetResult jsonResult = filterContext.Result as JsonNetResult;
                // See if the content length exceeds the percentage of the limit
                if ((double)jsonResult.ContentLength / MaxJsonLengthInBytes >= AlertPercentage)
                {
                    _systemWarningService.LogSizeWarning(filterContext.HttpContext.Request.RawUrl,
                        filterContext.HttpContext.User.Identity.Name,
                        jsonResult.ContentLength,
                        MaxJsonLengthInBytes);
                }
            }
        }
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }
    }
