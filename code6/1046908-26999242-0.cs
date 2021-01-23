            List<string> myList = new List<string>()
            {
                "My First String in List",
                "My Second String in List"
            };
            string[] myArray = new string[myList.Count];
            myList.CopyTo(myArray);
            Console.WriteLine("List Items:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Array Items:");
            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }
            Console.Read();
