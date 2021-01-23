    public class IAuthImplementation : IAuth
    {
        public IEnumerable<string> FindAccountsForService(string serviceId)
        {
            var query = new SecRecord(SecKind.GenericPassword);
            query.Service = serviceId;
            SecStatusCode result;
            var records = SecKeyChain.QueryAsRecord(query, 1000, out result);
            return records != null ?
                records.Select(GetAccountFromRecord).ToList() :
                new List<string>();
        }
        public void Save(string pin, string serviceId)
        {
            var statusCode = SecStatusCode.Success;
            var serializedAccount = pin;
            var data = NSData.FromString(serializedAccount, NSStringEncoding.UTF8);
            //
            // Remove any existing record
            //
            var existing = FindAccount(serviceId);
            if (existing != null)
            {
                var query = new SecRecord(SecKind.GenericPassword);
                query.Service = serviceId;
                statusCode = SecKeyChain.Remove(query);
                if (statusCode != SecStatusCode.Success)
                {
                    throw new Exception("Could not save account to KeyChain: " + statusCode);
                }
            }
            //
            // Add this record
            //
            var record = new SecRecord(SecKind.GenericPassword);
            record.Service = serviceId;
            record.Generic = data;
            record.Accessible = SecAccessible.WhenUnlocked;
            statusCode = SecKeyChain.Add(record);
            if (statusCode != SecStatusCode.Success)
            {
                throw new Exception("Could not save account to KeyChain: " + statusCode);
            }
        }
        public void Delete(string serviceId)
        {
            var query = new SecRecord(SecKind.GenericPassword);
            query.Service = serviceId;
            var statusCode = SecKeyChain.Remove(query);
            if (statusCode != SecStatusCode.Success)
            {
                throw new Exception("Could not delete account from KeyChain: " + statusCode);
            }
        }
        string GetAccountFromRecord(SecRecord r)
        {
            return NSString.FromData(r.Generic, NSStringEncoding.UTF8);
        }
        string FindAccount(string serviceId)
        {
            var query = new SecRecord(SecKind.GenericPassword);
            query.Service = serviceId;
            SecStatusCode result;
            var record = SecKeyChain.QueryAsRecord(query, out result);
            return record != null ? GetAccountFromRecord(record) : null;
        }
        public void CreateStore()
        {
            throw new NotImplementedException();
        }
    }
