    public class MyHostObject
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
    
    public class RoslynTest
    {
        public void Test()
        {
            var myHostObject = new MyHostObject
            {
                Value1 = "Testing Value 1",
                Value2 = "This is Value 2"
            };
            var engine = new ScriptEngine();
            var session = engine.CreateSession(myHostObject);
            session.AddReference(myHostObject.GetType().Assembly.Location);
            session.AddReference("System");
            session.AddReference("System.Core");
            session.ImportNamespace("System");
            
            // "Execute" our method so we can call it.
            session.Execute("public string UpdateHostObject() { Value1 = \"V1\"; Value2 = \"V2\"; return Value1 + Value2;}");
            var s = session.Execute<string>("UpdateHostObject()");
            //s will return "V1V2" and your instance of myHostObject was also changed.
        }
    }
