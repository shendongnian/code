    public static class Extensions 
    {
        public static bool HasFullAccess(this int mask)
        { 
            return mask % 2 == 1;
        }
    }
