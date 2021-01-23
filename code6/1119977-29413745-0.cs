    class Program
    {
        static List<string> _firstList;
        static List<string> _secondList;
        static void Main(string[] args)
        {
            // Initialize test values
            Setup();
            // Group the items in the first list
            var duplicates = _firstList
                .GroupBy(item => item)
                .Where(g => g.Count() > 1)
                .Select(grp => new { grp.Key });
            // Iterate through each duplicate in the group of duplicate items and add them to the second list.
            foreach (var duplicate in duplicates)
            {
                _secondList.Add(duplicate.Key);
            }
            // Display the results
            Display();
            Console.ReadLine();
        }
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
        }
        static void Display()
        {
            Console.WriteLine("Duplicate items found in list 1 are:\n------------------------------------");
            foreach (var item in _secondList)
            {
                Console.WriteLine(item);
            }
        }
