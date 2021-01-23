    public class Baz { }
    public class Foo
    {
        public void Bar()
        {
            if (false)
            {
                // Will be flagged as unreachable code
                var baz = new Baz();
            }
            var true_in_debug_false_in_release =
                GetType()
                .GetMethod("Bar")
                .GetMethodBody()
                .LocalVariables
                .Any(x => x.LocalType == typeof(Baz));
            Console.WriteLine(true_in_debug_false_in_release);
        }
    }
