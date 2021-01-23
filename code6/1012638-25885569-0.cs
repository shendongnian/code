    public int UpdateAccountBySAN(string SamAccountName, string Surname, string GivenName, string EmailAddress,bool Enabled, string Guid, string DateCreated, string DateModified, string SID,string EmployeeNumber)
        {
            DataAccessTier.GW_UTADataSetTableAdapters.ActiveDirectory2TableAdapter
                ActiveDirectory2TableAdapter1
                    = new DataAccessTier.GW_UTADataSetTableAdapters.ActiveDirectory2TableAdapter();
            return ActiveDirectory2TableAdapter1.UpdateBySAN(SamAccountName, Surname, GivenName,
            EmailAddress, Enabled, Guid, DateCreated, DateModified, SID, EmployeeNumber);
        }
