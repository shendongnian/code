    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace shekhar_final
    {
        public class Huffman{
        public  int data_size,length,i,is_there, total_nodes;
        string code;
         public   Huffman(char  *args) //called from MyClass  Line:16
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
             Huffman ObjSym =new Huffman(args);//object creation
           }
       }
    }// Line:34
