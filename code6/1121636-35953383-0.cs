    /// <summary>
    /// Extensions to help adding middleware to the OWIN pipeline
    /// </summary>
    public static class OwinExtensions
    {
        /// <summary>
        /// Add Application Insight Request Tracking to the OWIN pipeline
        /// </summary>
        /// <param name="app"><see cref="IAppBuilder"/></param>
        public static void UseApplicationInsights(this IAppBuilder app) => app.Use(typeof(ApplicationInsights));
    }
    /// <summary>
    /// Allows for tracking requests via Application Insight
    /// </summary>
    public class ApplicationInsights : OwinMiddleware
    {
        /// <summary>
        /// Allows for tracking requests via Application Insight
        /// </summary>
        /// <param name="next"><see cref="OwinMiddleware"/></param>
        public ApplicationInsights(OwinMiddleware next) : base(next)
        {
        }
        /// <summary>
        /// Tracks the request and sends telemetry to application insights
        /// </summary>
        /// <param name="context"><see cref="IOwinContext"/></param>
        /// <returns></returns>
        public override async Task Invoke(IOwinContext context)
        {
            // Start Time Tracking
            var sw = new Stopwatch();
            var startTime = DateTimeOffset.Now;
            sw.Start();
            await Next.Invoke(context);
            // Send tracking to AI on request completion
            sw.Stop();
            var request = new RequestTelemetry(
                name: context.Request.Path.Value,
                startTime: startTime,
                duration: sw.Elapsed,
                responseCode: context.Response.StatusCode.ToString(),
                success: context.Response.StatusCode >= 200 && context.Response.StatusCode < 300
                )
            {
                Url = context.Request.Uri,
                HttpMethod = context.Request.Method
            };
            var client = new TelemetryClient();
            client.TrackRequest(request);
        }
    }
