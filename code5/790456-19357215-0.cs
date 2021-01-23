            String someString = null;
            if (someString != null && someString[4].Equals('a'))
            {
                //// not called
            }
            if (someString != null || someString[4].Equals('a'))
            {
                //// exception
            }
            Console.ReadLine();
