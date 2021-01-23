    class Program
    {
        static void Main()
        {
    	byte[] original = new byte[10];
    	original[0] = 1;
    
    	int[] destination = new int[10];
    
    	// This will work if you call Array.Copy instead.
    	Array.ConstrainedCopy(original, 0, destination, 0, original.Length);
        }
    }
