        private void Method2(object obj)
        {
            var nested = (Private2.Nested)obj;
            Console.WriteLine(nested.GetType()); //prints Private1.Nested
        }
