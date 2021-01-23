    public bool ClearOrphnedIDs(List<Person> Persons, List<Template> Templates)
    {
        bool isClearComplete = false;
        try
        {
            if (Persons != null && Templates != null)
            {
                var personsSet = new HashSet<string>(Persons.Select(p => p.PersonId));
                var orphnedTemplatesNeedToIgnore = new HastSet<string>();
                foreach (var template in Templates)
                {
                    if (!personsSet.Contains(template.PersonID) && !orphnedTemplatesNeedToIgnore.Contains(personID))
                    {
                            orphnedTemplatesNeedToIgnore.Add(template.PersonID);
                            DataSyncLog.Warn(string.Format("Templates with personID {0} is orphned (has no person entry) in DB", template.PersonID));
                    }
    
                }
                if (orphnedTemplatesNeedToIgnore.Count > 0)
                    Templates.RemoveAll(t => orphnedTemplatesNeedToIgnore.Contains(t.PersonID));
                isClearComplete = true;
            }
        }
        catch (Exception ex)
        {
            DataSyncLog.Debug(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "::" + System.Reflection.MethodBase.GetCurrentMethod().ToString() + " :: " + ex.Message + " :: " + ex.StackTrace);
        }
        return isClearComplete;
    }
