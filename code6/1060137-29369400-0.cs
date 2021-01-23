     public async Task<Result<dynamic>> addUserToAzureGroup(Group AzGroup, User AzUser)
        {
            // link the found user with the found group
            try
            {
                AzGroup.Members.Add(AzUser as DirectoryObject);
                await AzGroup.UpdateAsync();
            }
            catch (Exception ex)
            {
                Exception myEx = new Exception(ex.Message);
                retResult.Exception = myEx;
                return retResult;
            }
            return retResult;
        }
