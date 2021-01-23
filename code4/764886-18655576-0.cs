     public bool ClearOrphnedIDs(List<Person> Persons, List<Template> Templates)
        {
            bool isClearComplete = false;
            try
            {
                if (Persons != null && Templates != null)
                {
                    HashSet<string> personsSet = new HashSet<string>(Persons.Select(p => p.PersonID));
                    HashSet<string> templateSet = new HashSet<string>(Templates.Select(t => t.PersonID));
                    HashSet<string> orphanedIds =new HashSet<string>(templateSet.Except(personsSet));
                    if (orphanedIds.Count > 0)
                        Templates.RemoveAll(t => orphanedIds.Contains(t.PersonID));
                        isClearComplete = true;
                }
            }
            catch (Exception ex)
            {
                DataSyncLog.Debug(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "::" + System.Reflection.MethodBase.GetCurrentMethod().ToString() + " :: " + ex.Message + " :: " + ex.StackTrace);
            }
            return isClearComplete;
        }
