    public class MyScriptableManagedType {
            [ScriptableMember()]
            public string MyToUpper(string str) {
                return str.ToUpper();
            }
    
            [ScriptableMember()]
            public string Name { get; set; }
    }
