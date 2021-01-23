            List<string> myList = new List<string>()
            {
                "My First String in List",
                "My Second String in List"
            };
            string[] myArray = new string[] { "My Array First String" };
            List<string> myArrayList = new List<string>();
            foreach (var item in myArray)
            {
                myArrayList.Add(item);
            }
            foreach (var item in myList)
            {
                myArrayList.Add(item);
            }
            foreach (var item in myArrayList)
            {
                Console.WriteLine(item);
            }
            Console.Read();
