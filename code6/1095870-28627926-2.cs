    public class AuditLog
        {
            public int Id { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedOn { get; set; }
            public AuditEventType EventType { get; set; }
            public string TableName { get; set; }
            public int EntityId { get; set; }
            public string ColumnName { get; set; }
            public string Controller { get; set; }
            public string Action { get; set; }
            public string IPAddress { get; set; }
            public string OriginalValue { get; set; }
            public string NewValue { get; set; }
        }
