    namespace final_version_Csharp
    {
        public Class Huffman<K> where K :  IComparable<K>
        {
            public classNode<K> 
            {
                public Node next, left, right;
                public K symbol;
                public int freq;
            }
            public Node root;
        }
    ...
        public class MyClass 
        {
            public static void Main(string[] args) 
              {
                Huffman ObjSym = new Huffman<int>(); 
                //All other methods are here
                ObjSym.huffman_node_processing(); //this for adding the two minimum nodes
                ObjSym.GenerateCode(ObjSym.root, ""); //this for encoding
               }
        }
    }
