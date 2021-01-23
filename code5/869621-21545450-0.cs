    private static void GetAudit<TRequest, TResponse>(TRequest request, TResponse response, int memberId, RemoteEndpointMessageProperty endpointProperty)
    {
        var auditSB = new StringBuilder();
        auditSB.Append("Req:");
        auditSB.Append(Util.Serialize(request).ToString(CultureInfo.InvariantCulture));
        auditSB.Append("Res:");
        auditSB.Append(Util.Serialize(response).ToString(CultureInfo.InvariantCulture));
        if (request is ChangePasswordRequest)
        {
            // check if TResponse is ChangePasswordResponse
            // throw ArgumentException if TResponse is not right type
            
            var changePasswordRequest = TRequest as ChangePasswordRequest;
            Audit.Add(AuditEventType.UpdatePassword, Severity.Normal, memberId,
                changePasswordRequest.TokenId,
                auditSB.ToString(),
                endpointProperty.Address, changePasswordRequest.IpAddress);
        }
        else if (request is LoadSupplierRequest)
        {
            // check if TResponse is LoadSupplierResponse
            // throw ArgumentException if TResponse is not right type
            // do Auditing
        }
        else
        {
            throw new ArgumentException("Invalid Request type");
        }
    }
