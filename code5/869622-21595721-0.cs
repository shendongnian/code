    private static void LogNormalAudit<TRequest, TResponse>(TRequest request, TResponse response,
            IRequest objRequest, int memberId, AuditEventType eventType)
        {
            bool isNormalSeverityOn = Convert.ToBoolean(ConfigurationSystem.SharedApiConfig["normal"]);
            if (!isNormalSeverityOn) return;
            var auditText = string.Format("Req: {0} |Rsp: {1}", Util.Serialize(request), Util.Serialize(response));
            Audit.Add(eventType, Severity.Normal, memberId, objRequest.TokenId, auditText, GetClientIp(),
                objRequest.IpAddress);
        }
