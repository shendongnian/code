    using System;
    using InterSystems.Globals;
    class FetchNodes {
      public static void Main(String[] args) {
        Connection myConn = ConnectionContext.GetConnection();
        try {
          myConn.Connect("User", "_SYSTEM", "SYS");
          NodeReference nodeRef = myConn.CreateNodeReference("myGlobal");
          // Read both existing nodes
          Console.WriteLine("Value of ^myGlobal is " + nodeRef.GetString());
          Console.WriteLine("Value of ^myGlobal(\"sub1\") is " + nodeRef.GetString("sub1"));
          nodeRef.Kill();   // delete entire array
          nodeRef.Close();
          myConn.Close();
        }
        catch (GlobalsException e) { Console.WriteLine(e.Message); }
      } // end Main()
    } // end class FetchNodes
 
