    namespace shekhar_final
    {
        class Huffman 
        {
    	    public int DataSize {get; set;}
            public int Length {get; set;}
            public int I {get;set;}
            public int IsThere {get;set;}
            public int TotalNodes {get;set;}
    	    private string code;
    
    	    public Huffman(string[] args) //called from MyClass  Line:16
            {
                using (var stream = new BinaryReader(System.IO.File.OpenRead(args[0])))  //Line : 18
                {
                    while (stream.BaseStream.Position < stream.BaseStream.Length)
                    {
                        byte processingValue = stream.ReadByte();
                    }
                }
            }
    	}
    	
        public class MyClass 
        {
            public static void Main(string[] args)
            {       
               Huffman objSym = new Huffman(args);//object creation
            }
        }
    }// Line:34
