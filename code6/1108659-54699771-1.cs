    class AppInsightCustomProps : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;
            // Is this a TrackRequest() ?
            if (requestTelemetry == null) return;
            var httpCtx = HttpContext.Current;
            if (httpCtx != null)
            {
                var customPropVal = (string)httpCtx.Items["PerRequestMyCustomProp"];
                if (!string.IsNullOrWhiteSpace(customPropVal))
                {
                    requestTelemetry.Properties["MyCustomProp"] = customPropVal;
                }
            }
        }
    }
