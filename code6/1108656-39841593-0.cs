    public class CustomTelemetry : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;
            if (requestTelemetry == null) return;
            requestTelemetry.Properties.Add("LoggedInUserName", "DummyUser");
        }
    }
