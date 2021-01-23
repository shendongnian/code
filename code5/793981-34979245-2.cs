    public class CssClass
    {
        public string Name { get; private set; }
        public static CssClass In = new CssClass("in");
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="T:System.Object"/>.
        /// </summary>
        private CssClass(string name)
        {
            Name = name;
        }
    }
