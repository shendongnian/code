       class Sample
       {
           public int A;
           public long B;
           public short C;
           public short D;
       }
    
       static unsafe void Main(string[] args)
       {
          Sample s = new Sample {A = 0x01020304, B = 0x0f0e0d0c0b0a0908, C = 0x0706, D = 0x0504};
          long a = 1;
          long b = 2;
          long* pA = &a;
          long* pB = &b;
          Console.WriteLine("{0:x16}", *pB);
          Console.WriteLine("{0:x16}", *(pB - 1));
          Console.WriteLine("{0:x16}", *(pB - 2));
     
          long prS = (long)(pB - 2); // the location of s on the stack
          long* pS = *(long**)prS;
          Console.WriteLine("{0:x16}", *pS);
          Console.WriteLine("{0:x16}", *(pS + 1));
          Console.WriteLine("{0:x16}", *(pS + 2));
       
          Console.ReadLine();
     }
