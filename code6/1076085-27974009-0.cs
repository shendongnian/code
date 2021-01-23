    using System;
    using System.IO;
    using System.Text;
    using NLua;
    
    namespace GetLuaTable
    {
        class Program
        {
            public static Lua netLua;
    
            static void Main(string[] args)
            {
    
                netLua = new Lua();
    
                CShaprFunction cShapr = new CShaprFunction();
                netLua.RegisterFunction("CShaprConsoleLine", cShapr, cShapr.GetType().GetMethod("CShaprConsoleLine"));
                netLua.RegisterFunction("CSharpGetTableFromStr", cShapr, cShapr.GetType().GetMethod("CSharpGetTableFromStr"));
                netLua.DoString(@"
                function main()
                    CShaprConsoleLine(""Start"")
                    local tmptable = CSharpGetTableFromStr(""a"")
                    CShaprConsoleLine(type(tmptable))  
                    CShaprConsoleLine(""end"")
                  end
                ");
                netLua.GetFunction("main").Call();
                Console.ReadKey();
            }
        }
        class CShaprFunction
        {
            public void CShaprConsoleLine(object obj)
            {
                Console.WriteLine(obj);
            }
            public LuaTable CSharpGetTableFromStr(string name)
            {
                var lua = Program.netLua;
                lua.DoString("a={\"test\"}");
                LuaTable tab = lua.GetTable(name);
                return tab;
            }
        }
    }
