    class Program
    {
        static List<string> _firstList;
        static List<string> _secondList;
        static void Main(string[] args)
        {
            // Initialize test values
            Setup();
            // Fill list 2 with all items in list 1 where the item is a value and remove the item
            // from list 1.
            FillListTwoWithSpecificValue("Test 1");
            /* Uncomment the line below if you want to populate list 2 with all duplicate items
                         while removing them from list 1.*/
            // FillListWithAllDuplicates();
            // Display the results
            Display();
            Console.ReadLine();
        }
        // Bonus method.  Fills list 2 with any instance of a duplicate item pre-existing in list 1 while removing the item from the list.
        static void FillListWithAllDuplicates()
        {
            // Group the items in the first list
            var duplicates = _firstList
                .GroupBy(item => item)
                .Where(g => g.Count() > 1)
                .Select(grp => new { grp.Key });
            // Iterate through each duplicate in the group of duplicate items and add them to the second list and remove it from the first.
            foreach (var duplicate in duplicates)
            {
                _secondList.Add(duplicate.Key);
                // Remove all instances of the duplicate value from the first list.
                _firstList.RemoveAll(item => item == duplicate.Key);
            }
        }
        // Fill list 2 with any instance of a value provided as a parameter (eg. Test 1) and remove the same value from list 1.
        static void FillListTwoWithSpecificValue(string value)
        {
            // Group the items in the first list, and select a group according to the value provided.
            var duplicates = _firstList
                .GroupBy(item => item)
                .SelectMany(grp => grp.Where(item => item == value));
            // Iterate through each duplicate in the group of duplicate items and add them to the second list and remove it from the first.
            foreach (string duplicate in duplicates)
            {
                _secondList.Add(duplicate);
                // Remove all instances of the duplicate value from the first list.
                _firstList.RemoveAll(item => item == duplicate);
            }
        }
        // Simply a method to initialize the lists with dummy data.  This is only meant to keep the code organized.
        static void Setup()
        {
            // Initialize lists
            _firstList = new List<string>()
            {
                "Test 1",
                "Test 1",
                "Test 2",
                "Test 3",
                "Test 3",
                "Test 4",
                "Test 4",
                "Test 5",
                "Test 6",
            };
            _secondList = new List<string>();
            // Display the list values for comparison.
            Console.WriteLine("Items contained in list 1 before items moved to list 2:\n------------------------------------");
            foreach (var item in _firstList)
            {
                Console.WriteLine(item);
            }
        }
        // Simply a method to display the output to the console for the purpose of demonstration.  This is only meant to keep the code organized.
        static void Display()
        {
            Console.WriteLine("\nItems now in list 1 after duplicates being removed:\n------------------------------------");
            foreach (var item in _firstList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nItems now in list 2 are:\n------------------------------------");
            foreach (var item in _secondList)
            {
                Console.WriteLine(item);
            }
        }
    }
