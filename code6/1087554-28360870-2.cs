    public static class ExtensionMethods
    {
        public static string UppercaseFirstLetter(this string value)
        {
    	    // Uppercase the first letter in the string this extension is called on.
    	    if (value.Length > 0)
    	    {
    	        char[] array = value.ToCharArray();
    	        array[0] = char.ToUpper(array[0]);
    	        return new string(array);
    	    }
    	    return value;
        }
    }
    
    class Program
    {
        static void Main()
        {
    	    // Use the string extension method on this value.
    	    string value = "dot net perls";
    	    value = value.UppercaseFirstLetter(); // Called like an instance method.
    	    Console.WriteLine(value);
        }
    }
