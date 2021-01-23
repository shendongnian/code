        private static bool DeleteKeePassEntry(PwDatabase pwDatabase, PwEntry pwEntry)
        {
            try
            {
                PwDeletedObject pwDeletedObject = new PwDeletedObject(pwEntry.Uuid, DateTime.Now);
                pwDatabase.DeletedObjects.Add(pwDeletedObject);
                pwDatabase.MergeIn(pwDatabase, PwMergeMethod.Synchronize);
                pwDatabase.Save(new CoutLogger());
            }
            catch (Exception e)
            {
                Log.UpdateLog(e.Message);
                if (e.InnerException != null)
                    Log.UpdateLog(e.InnerException.Message);
                return Global.ERROR;
            }
            /* success */
            return Global.OK;
        }
