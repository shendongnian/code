    /// <summary>
    /// Represents your player class.
    /// </summary>
    class Player
    {
        /// <summary>
        /// Gets or sets the health of the player.
        /// </summary>
        [DebugExtensions.DebugMePlease()]
        public int Health { get; set; }
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets a string representation of the player object.
        /// </summary>
        /// <returns>The player object as string representation.</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
    /// <summary>
    /// Contains some extensions useful for debugging.
    /// </summary>
    public static class DebugExtensions
    {
        /// <summary>
        /// Represents our custom attribute called "DebugMePlease".
        /// Properties marked with this attribute will be printed automatically.
        /// </summary>
        public class DebugMePlease : Attribute
        {
        }
        /// <summary>
        /// Continas all objects that shall be monitored.
        /// </summary>
        public static List<object> DebugList
        {
            get;
            set;
        }
        /// <summary>
        /// Initializes static members of the <see cref="DebugExtensions"/> class.
        /// </summary>
        static DebugExtensions()
        {
            DebugList = new List<object>();
        }
        /// <summary>
        /// Prints the values of all objects in the debugList.
        /// </summary>
        public static void Print()
        {
            foreach (object o in DebugList)
            {
                var members = from member in o.GetType().GetProperties()
                              from attribute in member.GetCustomAttributes(typeof(DebugMePlease), true)
                              select member;
                foreach (var z in members)
                {
                    Console.WriteLine(string.Format("{0}, {1}: {2}", o.ToString(), z.Name, z.GetValue(o)));
                }
            }
        }
    }
    /// <summary>
    /// Contains the entry point of our application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of our application. 
        /// </summary>
        /// <param name="args">Possibly specified command line arguments.</param>
        public static void Main(string[] args)
        {
            Player t = new Player();
            t.Name = "Chuck Norris";
            t.Health = int.MaxValue; // Becaus it's Chuck Norris ;-)
            // Add the object to the debug list.
            DebugExtensions.DebugList.Add(t);
            // Print all properties marked with the "DebugMePlease" attribute.
            DebugExtensions.Print();
            // Change something.
            t.Health = 0;
            
            // Print again and hopefully be happy.
            DebugExtensions.Print();
            Console.ReadLine();
        }
    }
