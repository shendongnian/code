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
            
