    public static class QueryExtensions
    {
        public static bool HasMapping(this Demand role)
        {
            return role.DemandMappings.Count > 0;
        }
    }
