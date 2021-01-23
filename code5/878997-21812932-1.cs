    public class AuditTableA : IAudit
    {
        [AutoIncrement]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class AuditTableB : IAudit
    {
        [AutoIncrement]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
### 
    var a = new AuditTableA();
    var b = new AuditTableB();
    db.Save(a);
    db.Save(b);
    var insertRowA = db.SingleById<AuditTableA>(a.Id);
    var insertRowB = db.SingleById<AuditTableB>(b.Id);
    //both insertRowA/insertRowB CreatedDate/ModifiedDate fields populated
