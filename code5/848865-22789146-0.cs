    In Generic repository pattern, we can write a generic event handler for db context savechanges event.
    
    I googled it and gathered few many information.
    
    1. I dont want to write a sql server trigger
    2. I dont want to handle savechanges method in each entity.
    So i am planning to write generic single method 
    Db structure that I am using
    
    audit table
    
    CREATE TABLE [dbo].[Audit](
    	[Id] [BIGINT] IDENTITY(1,1) NOT NULL,
    	[TableName] [nvarchar](250) NULL,
    	[Updated By] [nvarchar](100) NULL,
    	[Actions] [nvarchar](25) NULL,
    	[OldData] [text] NULL,
    	[NewData] [text] NULL,
    	[Created For] varchar(200) NULL,
    	[Updated Date] [datetime] NULL,
     CONSTRAINT [PK_DBAudit] PRIMARY KEY CLUSTERED 
    (
    	[Id] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    
    2.Update your dbcontext with Audit table entity.
    
    3.Hook generic event handler for Dbcontext savechanges   
    c# code
        namespace ARMS.Domain      
        {
            using System;
            using System.Collections.Generic;
            using System.Collections.ObjectModel;
            using System.Data;
            using System.Data.Objects;
            using System.Linq;
            using System.Text;
            using System.ComponentModel.DataAnnotations;
            public partial class ARMSContext
            {
                Collection<Audit> auditTrailList = new Collection<Audit>();
                partial void OnContextCreated()
                { 
                    this.SavingChanges += new EventHandler(ArmsEntities_SavingChanges);
                }
                public enum AuditActions
                {
                    Added,
                    Modified,
                    Deleted
                }
                void ArmsEntities_SavingChanges(object sender, EventArgs e)
                { 
                    auditTrailList.Clear(); 
                    IEnumerable<ObjectStateEntry> changes =
                        this.ObjectStateManager.GetObjectStateEntries(
                        EntityState.Added | EntityState.Deleted | EntityState.Modified); 
                    foreach (ObjectStateEntry stateEntryEntity in changes)
                    {
                        
                        
                            if (!stateEntryEntity.IsRelationship && stateEntryEntity.Entity != null && !(stateEntryEntity.Entity is Audit))
                            {
                                Audit audit = this.GetAudit(stateEntryEntity);
                                auditTrailList.Add(audit);
                            }
                    
                    }
                    if (auditTrailList.Count > 0)
                    {
                        foreach (var audit in auditTrailList)
                        {
                            this.Audits.AddObject(audit);  
                        } 
                    }
                }
                public Audit GetAudit(ObjectStateEntry entry)
                {
                    Audit audit = new Audit();
           
                    audit.Updated_By ="Test";
                    audit.TableName = entry.EntitySet.ToString();
                    audit.Updated_Date = DateTime.Now;
                    audit.Created_For = Convert.ToString(entry.Entity);
                    audit.Actions = Enum.Parse(typeof(AuditActions),entry.State.ToString(), true).ToString();
                    StringBuilder newValues = new StringBuilder();
                    StringBuilder oldValues = new StringBuilder();
                    if (entry.State == EntityState.Added)
                    {  
                        SetAddedProperties(entry, newValues);
                        audit.NewData = newValues.ToString();  
                    } 
                    else if (entry.State == EntityState.Deleted)
                    {   SetDeletedProperties(entry, oldValues);
                        audit.OldData = oldValues.ToString(); 
                    } 
                    else if (entry.State == EntityState.Modified)
                    { 
                        SetModifiedProperties(entry, oldValues, newValues);
                        audit.OldData = oldValues.ToString();
                        audit.NewData = newValues.ToString(); 
                    } 
                    return audit;
                } 
                private void SetAddedProperties(ObjectStateEntry entry, StringBuilder newData)
                {      
                    CurrentValueRecord currentValues = entry.CurrentValues;
                    for (int i = 0; i < currentValues.FieldCount; i++)
                    {  
                        newData.AppendFormat("{0}={1} || ", currentValues.GetName(i), currentValues.GetValue(i));
                    } 
                } 
                private void SetDeletedProperties(ObjectStateEntry entry, StringBuilder oldData)
                {
                    foreach (var propertyName in entry.GetModifiedProperties())
                    {
                        var oldVal = entry.OriginalValues[propertyName];
                        if (oldVal != null)
                        {
                            oldData.AppendFormat("{0}={1} || ", propertyName, oldVal);
                        }
                    }
                } 
                private void SetModifiedProperties(ObjectStateEntry entry, StringBuilder oldData, StringBuilder newData)
                {         
                    foreach (var propertyName in entry.GetModifiedProperties())
                    {
                        var oldVal = entry.OriginalValues[propertyName];
                        var newVal = entry.CurrentValues[propertyName];
                        if (oldVal != null && newVal != null && !Equals(oldVal, newVal))
                        {
                            newData.AppendFormat("{0}={1} || ", propertyName, newVal);
                            oldData.AppendFormat("{0}={1} || ", propertyName, oldVal);
                        }
                    } 
                }   
            }
        }
            
