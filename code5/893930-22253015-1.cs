    public bool UpdateVariables()
    {
        try
        {
			IEdmBatchUpdate2 update = this.Vault.CreateUtility(EdmUtility.EdmUtil_BatchUpdate) as IEdmBatchUpdate2;
			
			for (int i = 0; i < foundExcelRows.Count(); i++)
			{
					// bunch of code                
					update.SetVar(importFile.FileID, variable.DestinationVarID, ref value, defaultConfig, 0);
			}
			Array errors = Array.CreateInstance(typeof(EdmBatchError), 0);
        
            update.CommitUpdate(out errors, null); // COM Call -> Crashes here
            return true;
        }
        catch (Exception ex)
        {
                log.Error("update error", ex);
            return false;
        }
    }
