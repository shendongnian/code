    using System;
    using System.Linq;
    
    class Machine
    {
      public string MachineName;
      public Operation[] Operations;
    }
    
    class Operation
    {
      public string OperationName;
      public Tool[] Tools;
    }
    
    class Tool
    {
      public string ToolName;
      public Tool(string name) { ToolName = name; }
    }
    
    class App
    {
      static void Main()
      {
        var machines = new[] 
        {
          new Machine {
            MachineName = "A", Operations = new[] { new Operation { OperationName = "O1", Tools = new[] { new Tool("T1") } } }
          },
          new Machine {
            MachineName = "B", Operations = new[] { new Operation { OperationName = "O3", Tools = new Tool[0] } }
          },
          new Machine {
            MachineName = "C", Operations = new Operation[0]
          }
        };
    
        var defaultOp = new Operation() { Tools = new Tool[0] };
        var defaultTool = new Tool("");
    
        var res = 
        from m in machines
        from o in m.Operations.DefaultIfEmpty(defaultOp)
        from t in o.Tools.DefaultIfEmpty(defaultTool)
        group t by m.MachineName;
    
        foreach(var g in res)
        {
          Console.WriteLine(g.Key + "=" + string.Join(";", g.Select(x => x.ToolName)));
        }
      }
    }
