    /// <summary>
        /// This method will find and remove the Template entries that has no person entris
        /// from List<Template> Templates
        /// </summary>
        /// <param name="Persons"></param>
        /// <param name="Templates"></param>
        public bool ClearOrphnedIDs(List<Person> Persons, List<Template> Templates)
        {
            bool isClearComplete = false;
            try
            {
                if (Persons != null && Templates != null)
                {
                    HashSet<string> personsSet = new HashSet<string>(Persons.Select(p => p.PersonID));
                    Templates.RemoveAll(t => !personsSet.Contains(t.PersonID));
                    isClearComplete = true;
                }
            }
            catch (Exception ex)
            {
                DataSyncLog.Debug(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "::" + System.Reflection.MethodBase.GetCurrentMethod().ToString() + " :: " + ex.Message + " :: " + ex.StackTrace);
            }
            return isClearComplete;
        }
        /// <summary>
        /// This method will Find and remove the Person and template entries that has 
        /// zero or odd number of templates. from List<Person> Persons and List<Template> Templates
        /// </summary>
        /// <param name="Persons"></param>
        /// <param name="Templates"></param>
        public bool ClearInconsistantIDs(List<Person> Persons, List<Template> Templates)
        {
            bool isClearComplete = false;
            try
            {
                if (Persons != null && Templates != null)
                {
                    HashSet<string> inconsistantIDs = new HashSet<string>(
                      Persons.Select(p => p.PersonID).Where(p =>
                      {
                          var count = Templates.Count(t => t.PersonID == p);
                          return count == 0 || count % 2 != 0;
                      }
                      ));
                   
                    if (inconsistantIDs.Count > 0)
                    {
                        Templates.RemoveAll(t => inconsistantIDs.Contains(t.PersonID));
                        Persons.RemoveAll(p => inconsistantIDs.Contains(p.PersonID));
                    }
                    isClearComplete = true;
                }
            }
            catch (Exception ex)
            {
                DataSyncLog.Debug(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "::" + System.Reflection.MethodBase.GetCurrentMethod().ToString() + " :: " + ex.Message + " :: " + ex.StackTrace);
            }
            return isClearComplete;
        }
