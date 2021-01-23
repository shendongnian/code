    $ csharp
    Mono C# Shell, type "help;" for help
    
    Enter statements below.
    csharp> public static class Foo {
          >  
          > public static KeyValuePair<string,string> SplitToKeyValue(string text) {
          >     Regex p = new Regex(@"^(\w+)\s+(.*)$");
          >     Match m = p.Match(text);
          >     return new KeyValuePair<string,string>(m.Groups[1].Value,m.Groups[2].Value);
          > }
          >  
          > public static IEnumerable<string> Lines (string text) { 
          >     string line;
          >     using (StringReader reader = new StringReader(text)) {
          >         while ((line = reader.ReadLine()) != null) {
          >             yield return line;
          >         }
          >     }
          > }
          >  
          > }
    csharp> string inp = "LOAD =5.01E+10\nMPY $1\nADD $2";
    csharp> new LinkedList<KeyValuePair<string,string>>(Foo.Lines(inp).Select(Foo.SplitToKeyValue)) 
    { [LOAD, =5.01E+10], [MPY, $1], [ADD, $2] }
