     public static class MyExtensions
       {
         public static string SplitRemove(this String str,int arrayIndex,int charToRemove)
         {
            return str.Split(new char[] { '|' },
                             StringSplitOptions.RemoveEmptyEntries)   [arrayIndex].Remove(0,charToRemove);
        }
    }   
