        private static void Hello()
        {
            {
                int i = 0;
            }
            {
                Console.WriteLine(i);    //The name i does not exist in the current context.
            }
        }
