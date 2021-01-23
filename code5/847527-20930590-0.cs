    class Program
    {
        public class Foo
        {
            int number = 38;
        }
        static void Main( string[] args )
        {
            Foo foo = new Foo(); //create a new instance of the type that contains variable that you want the value of
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static; //define binding flags
            FieldInfo field = foo.GetType().GetField( "number", bindFlags ); //get the field from the object that has this name
            Object value = field.GetValue( foo ); //get the value of the field.
            Console.WriteLine( value.ToString() ); //output the value to the console.
        }
    }
