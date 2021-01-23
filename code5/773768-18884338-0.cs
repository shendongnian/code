    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication20
    {
      class Program
      {
        static void Main( string[] args )
        {
          DoSomething() ;
          return ;
        }
        static void DoSomething()
        {
          try
          {
            DoSomethingThatFails() ;
          }
          catch( Exception e )
          {
            throw new InvalidOperationException( "This is the wrapper exception" , e ) ;
          }
        }
        static int DoSomethingThatFails()
        {
          int x = 3 ;
          int y = 0 ;
          int z = x / y ; // can you say "divide by zero"?
          return z ;
        }
      }
    }
