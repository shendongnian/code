    // object you want to create from the file lines.
    public class Foo
    {
        // add properties here....
    }
    // Parser only responsibility is create the objects.
    public class FooParser
    {
        public IEnumerable<Foo> ParseFile(string filename)
        {
            if(!File.Exists(filename))
                throw new FileNotFoundException("Could not find file to parse", filename);
            foreach(string line in File.ReadLines(filename))
            {
                Foo foo = CreateFoo(line);
                yield return foo;
            }
        }
        private Foo CreateFoo(string line)
        {
            // parse line/create instance of Foo here
            return new Foo {
                // ......
            };
        }
    }
