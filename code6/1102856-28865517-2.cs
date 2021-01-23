        class Foo
        {
            public string Bar { get; set; }
            public string Baz { get; set; }
            public override string ToString()
            {
                return (Bar ?? "") + " " + (Baz ?? "");
            }
        }
        delegate void propsetter(string prop, string value);
        private static void SetOnNonEmpty(PropertyInfo pi, Object o, string value)
        {
            if (pi.PropertyType != typeof(string))
                throw new ArgumentException("type mismatch on property");
            if (!String.IsNullOrEmpty(value))
                pi.SetValue(o, value);
        }
        static void Main(string[] args)
        {
            var myObj = new Foo();
            myObj.Baz = "nothing";
            PropertyInfo piBar = myObj.GetType().GetProperty("Bar");
            PropertyInfo piBaz = myObj.GetType().GetProperty("Baz");
            SetOnNonEmpty(piBar, myObj, "something");
            SetOnNonEmpty(piBaz, myObj, null);
            Console.WriteLine(myObj);
        }
