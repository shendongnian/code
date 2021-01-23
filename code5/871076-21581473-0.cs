    public static class StringExtensions{
       public static string ReverseString (this string value) 
       {
           var reversed = string.Join("",value.Reverse());
           return reversed;
       }
    }
