    class Program
    {
        static int _recordIndex;
        static List<StudentRecord> _studentRecords;
        static void Main(string[] args)
        {
            // Initialize a list of student records and set the record index to the index of the first record.
            _studentRecords = new List<StudentRecord>();
            _recordIndex = 0;
            // Read the lines of a file into a list of strings. Iterate through each
            // line and create a list of student records of elements by parsing (splitting) the line by a delimiter (eg. a comma).
            // Then display what's now contained within the list of records.
            var lines = ReadFile("dummy.txt");
            foreach (string line in lines)
            {
                _studentRecords.Add(CreateStudentResult(line)); 
            }
            Display();
            // Prevent the console window from closing.
            Console.ReadLine();
        }
        // Reads a file and returns an array of strings.
        static List<string> ReadFile(string fileName)
        {
            var lines = new List<string>();
            using (var file = new StreamReader(fileName))
            {
                string line = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
        // Get the next student record in the list of records
        static StudentRecord GetNext()
        {
            // Check to see if there are any records, if not... don't bother running the rest of the method.
            if (_studentRecords.Count == 0)
                return null;
            // If we are on the index of the last record in the list, set the record index back to the first record. 
            if (_recordIndex == _studentRecords.Count - 1)
            {
                _recordIndex = 0;
            }
            // Otherwise, simply increment the record index by 1.
            else
            {
                _recordIndex++;
            }
            // Return the record at the the new index.
            return _studentRecords[_recordIndex];
        }
        static StudentRecord GetPrevious()
        {
            // Check to see if there are any records, if not... don't bother running the rest of the method.
            if (_studentRecords.Count == 0)
                return null;
            // If we are on the index of the first record in the list, set the record index to the last record. 
            if (_recordIndex == 0)
            {
                _recordIndex = _studentRecords.Count - 1;
            }
            // Otherwise, simply deincrement the record index by 1.
            else
            {
                _recordIndex--;
            }
            // Return the record at the the new index.
            return _studentRecords[_recordIndex];
        }
        // Create a StudentResult object containing the string elements from a comma delimited string.
        static StudentRecord CreateStudentResult(string line)
        {
            var parts = line.Split(',');
            return new StudentRecord(parts[0], parts[1], parts[2], parts[3], parts[4]);
        }
        // Display the results to the console window for demonstration.
        static void Display()
        {
            // Display a list of all the records
            Console.WriteLine("Student records:\n----------------");
            foreach (var record in _studentRecords)
            {
                Console.WriteLine(record.ToString());
                Console.WriteLine();
            }
            // Display the first record in the list
            Console.WriteLine("First record is:\n----------------");
            Console.WriteLine(_studentRecords.First().ToString());
            Console.WriteLine();
            // Display the last record in the list.
            Console.WriteLine("Last record is:\n----------------");
            Console.WriteLine(_studentRecords.Last().ToString());
            Console.WriteLine();
            // Display the next record in the list
            Console.WriteLine("Next record is:\n----------------");
            Console.WriteLine(GetNext().ToString());
            Console.WriteLine();
            // Display the last record in the list.
            Console.WriteLine("Previous record is:\n----------------");
            Console.WriteLine(GetPrevious().ToString());
            Console.WriteLine();
        }
        // A record object used to store the elements of parsed string.  
        public class StudentRecord
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string Date { get; set; }
            public string Gender { get; set; }
            // Default constructor
            public StudentRecord()
            {
            }
            // Overloaded constructor that accepts the parts of a parsed or split string.
            public StudentRecord(string lastName, string firstName, string middleName, string date, string gender)
            {
                this.LastName = lastName;
                this.FirstName = firstName;
                this.MiddleName = middleName;
                this.Date = date;
                this.Gender = gender;
            }
            // Overrided ToString method which returns a string of property values.
            public override string ToString()
            {
                return string.Format(
                    "Last name: {0}\nFirst name: {1}\nMiddle name: {2}\nDate {3}\nGender: {4}",
                    this.LastName, this.FirstName, this.MiddleName, this.Date, this.Gender);
            }
        }
    }
