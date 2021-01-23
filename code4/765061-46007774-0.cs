        public class test
        {
            private static int funcValue()
            {
                return 200;
            }
            public static void someStaticFunc()
            {
                int x = funcValue();
            }
            public void anotherNonStaticFunc()
            {
                int y = funcValue();
            }
        }
