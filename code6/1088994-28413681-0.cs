    using AL =  Domain.AuditLog.AuditLog;
    namespace ApplicationServices.AuditLog
    {
        public interface IAuditLogService
        {
           List<AL> GetAuditLogs();
        }
    }
