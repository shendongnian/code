    public class Employee
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
            public bool IsEmployeed { get; set; }
            public string FullData
            {
                get
                {
                    return GetFullData();
                }
            }
    
            private string GetFullData()
            {
                return string.Format("Employee data - Name: {0}, Last name: {1}, Age: {2}, City: {3}, Is still employeed: {4}",
                    Name, LastName, Age, City,
                    (IsEmployeed ? "Yes" : "No"));
            }
        }
