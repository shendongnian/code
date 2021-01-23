    public static class SubExpertiseFilter
    {
        public static Expression<SubExpertise, bool> XorY =
             se => se.Description == "X" || se.Description == "Y";
    
    }
