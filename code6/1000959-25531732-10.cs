    var students = new List<Student>();
    string[] lines = File.ReadAllLines("my file path");
    CultureInfo southAfricanCuture = new CultureInfo("en-ZA");
    foreach (string l in lines) {
        DateTime d;
        if (DateTime.TryParseExact(l, "dd/MM/yyyy", southAfricanCuture,
                                   DateTimeStyles.AllowWhiteSpaces, out d))
        {
            students.Add(new Student { DOB = d });
        }
    }
