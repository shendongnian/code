        public class Bar { }
        public void Foo(params object[] objs)
        {
            foreach(object obj in objs)
            {
                Type typeofObject = obj.GetType();
                if (typeofObject == typeof(string))
                {
                    // Its a string
                }
                else if (typeofObject == typeof(int))
                {
                    // Its an integer
                }
                else if (typeofObject == typeof(Bar))
                {
                    // Its an Bar object
                }
            }
        }
