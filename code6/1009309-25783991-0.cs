    public int SaveChanges(object _olderInstance)
        {
            
            foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == System.Data.EntityState.Modified || p.State == System.Data.EntityState.Added || p.State == System.Data.EntityState.Deleted))
            {
                // For each changed record, get the audit record entries and add them
                //foreach (XmlTesst x in GetAuditRecordsForChange(ent))
                //{
                this.XmlTessts.Add(GetAuditRecordsForChange(ent));
                //}
            }
            // Call the original SaveChanges(), which will save both the changes made and the audit records
            return base.SaveChanges();
        }
        public XmlTesst GetAuditRecordsForChange(DbEntityEntry dbEntry)
        {
            string tableName, eventtype;
            XmlTesst XmlForReturn;
            if (dbEntry.State == System.Data.EntityState.Modified)
            {
                TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
                // Get table name (if it has a Table attribute, use that, otherwise get the pluralized name)
                tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;
                XmlDocument XmlCurrentDoc = new XmlDocument();
                XmlNode rootNodeCurrent = XmlCurrentDoc.CreateElement(tableName);
                XmlCurrentDoc.AppendChild(rootNodeCurrent);
                XmlDocument XmlOldDoc = new XmlDocument();
                XmlNode rootNodeOld = XmlOldDoc.CreateElement(tableName);
                XmlOldDoc.AppendChild(rootNodeOld);
                foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
                {
                    object CurrentValues = dbEntry.CurrentValues.GetValue<object>(propertyName);
                    object OriginalValues = dbEntry.Entity.GetType().GetProperty(propertyName).GetValue(_olderInstancea, null);
                    if (!object.Equals(dbEntry.Entity.GetType().GetProperty(propertyName).GetValue(_olderInstancea, null), CurrentValues) && (OriginalValues != null || CurrentValues != null))
                    {
                        XmlNode userNodeCurrent = XmlCurrentDoc.CreateElement(propertyName);
                        userNodeCurrent.InnerText = CurrentValues.ToString();
                        rootNodeCurrent.AppendChild(userNodeCurrent);
                        XmlNode userNodeOld = XmlOldDoc.CreateElement(propertyName);
                        if (OriginalValues == null)
                        {
                            userNodeOld.InnerText = "Not Assigned ";
                            rootNodeOld.AppendChild(userNodeOld);
                        }
                        else
                        {
                            userNodeOld.InnerText = OriginalValues.ToString();
                            rootNodeOld.AppendChild(userNodeOld);
                        }
                    }
                }
                XmlForReturn = new XmlTesst() { OriginalXml = GetXMLAsString(XmlOldDoc), CurrentXml = GetXMLAsString(XmlCurrentDoc), EventType = "Edited", TimeofActivity = DateTime.Now, UserName = HttpContext.Current.User.Identity.Name, Url = HttpContext.Current.Request.CurrentExecutionFilePath, Screen = tableName };
                return XmlForReturn;
