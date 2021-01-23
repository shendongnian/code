    private static string GetAccessCode()
    {
        using (EPOSEntities db = new EPOSEntities())
        {
            var clientAccessCodes = from e in db.ClientAccountAccesses
                                    where string.IsNullOrWhiteSpace(e.GUID)
                                    select e.GUID;
            return clientAccessCodes.FirstOrDefault();
        }
    }
