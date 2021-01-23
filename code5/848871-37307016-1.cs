    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web;
    
    namespace MVC_AuditTrail.Models
    {
        public class Student
        {
            public int StudentID { get; set; }
    
            public string Name { get; set; }
    
            public string  mobile { get; set; }
        }
    
        public  class Audit
        {
            public long Id { get; set; }
            public string TableName { get; set; }
            public string UserId { get; set; }
            public string Actions { get; set; }
            public string OldData { get; set; }
            public string NewData { get; set; }
            public Nullable<long> TableIdValue { get; set; }
            public Nullable<System.DateTime> UpdateDate { get; set; }
        }
    
    
        public class StdContext : DbContext
        {
            private AuditTrailFactory auditFactory;
            private List<Audit> auditList = new List<Audit>();
            private List<DbEntityEntry> objectList = new List<DbEntityEntry>();
            public StdContext() : base("stdConnection")
            {
                Database.SetInitializer<StdContext>(new CreateDatabaseIfNotExists<StdContext>());
            }
    
            public DbSet<Student> Student { get; set; }
            public DbSet<Audit> Audit { get; set; }
    
            public override int SaveChanges()
            {
                auditList.Clear();
                objectList.Clear();
                auditFactory = new AuditTrailFactory(this);
    
                var entityList = ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified);
                foreach (var entity in entityList)
                {
                    Audit audit = auditFactory.GetAudit(entity);
                    bool isValid = true;
                    if (entity.State == EntityState.Modified && string.IsNullOrWhiteSpace(audit.NewData) && string.IsNullOrWhiteSpace(audit.OldData))
                    {
                        isValid = false;
                    }
                    if (isValid)
                    {
                        auditList.Add(audit);
                        objectList.Add(entity);
                    }
                }
    
                var retVal = base.SaveChanges();
                if (auditList.Count > 0)
                {
                    int i = 0;
                    foreach (var audit in auditList)
                    {
                        if (audit.Actions == AuditActions.I.ToString())
                            audit.TableIdValue = auditFactory.GetKeyValue(objectList[i]);
                        this.Audit.Add(audit);
                        i++;
                    }
    
                    base.SaveChanges();
                }
    
                return retVal;
            }
        }
    }
