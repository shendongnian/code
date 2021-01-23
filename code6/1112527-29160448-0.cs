    using System;
    
    public class Test
    {
    	public static void Main()
    	{
            // make the instance
    		TagModalDB test= new TagModalDB();
    		
            // initialize the arrays
    		test.intialize();
    		
    		Console.WriteLine(test.IV[599]); // <= Will out 0 since default assignment of 0  to numberic types
    	}
    }
    
    // Your Struct 
    public struct TagModalDB
    {
        public float[]  IV;                   
        public char[]   FAI;                   
        public char[]   FD;                   
        public float[]  NCP;
        public float[]  NLH;
        
        // Here we initialize your arrays 
        public void intialize(){
        	IV=new float[600] ;
        	FAI= new char[600];
        	FD= new char[600];
        	NCP=new float[600];
        	NLH= new float[600];
        }
    }
