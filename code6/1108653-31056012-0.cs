        public void LogUserNameAndTenant(string userName, string tenantCode)
        {
            var request = new RequestTelemetry();
            request.Name = "My Request";
            request.Context.Properties["User Name"] = userName;
            request.Context.Properties["Tenant Code"] = tenantCode;
            var client = new TelemetryClient();
            client.TrackRequest(request);
        }
