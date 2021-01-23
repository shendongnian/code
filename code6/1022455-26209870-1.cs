    class Program
    {
        static void Main()
        {
            var foo = new Foo();
            var bar = foo;
            foo.Hit();
            bar.Hit();
        }
    }
    public static class Extensions
    {
        public static void Hit(this Foo foo, [CallerMemberName] string name = null, [CallerFilePath] string path = null, [CallerLineNumber] int lineNumber = -1)
        {
            string callerVariableName;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(stream);
                string csharpFile = reader.ReadToEnd();
                string[] lines = csharpFile.Split('\n');
                string callingLine = lines[lineNumber - 1];
                Match matchVariableName = Regex.Match(callingLine, @"([a-zA-Z]+[^\.]*)\.Hit\(\)");
                callerVariableName = matchVariableName.Groups[1].Value;
            }
            Console.WriteLine("\n///////////////////////////////");
            Console.WriteLine("Caller method name:   {0}", name);
            Console.WriteLine("Caller variable name: {0}", callerVariableName);
            Console.WriteLine("File Path:            {0}", path);
            Console.WriteLine("Line number:	         {0}", lineNumber);
        }
    }
    public class Foo
    {
    }
