    public class TestEntry
    {
        public string StudentName { get; set; }
        public int Score { get; set; }
    }
    public class SomeClass
    {
        readonly List<TestEntry> _testEntries = new List<TestEntry>();
        public void EnterTests()
        {
            _testEntries.Clear();
            var count = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                Console.WriteLine("Enter Student's Name:");
                var testEntry = new TestEntry();
                testEntry.StudentName = Console.ReadLine();
                Console.WriteLine("Enter Student's Score:");
                testEntry.Score = Convert.ToInt32(Console.ReadLine());
    
                _testEntries.Add(testEntry);
            }
        }
        public void PrintHighestScoringStudent()
        {
            var highestTest = _testEntries.OrderByDescending(x => x.Score).FirstOrDefault();
            if (highestTest == null)
            {
                Console.WriteLine("No tests entered.");
                return;
            }
            
            Console.WriteLine("{0} scored {1}", highestTest.StudentName, highestTest.Score);
        }
    }
