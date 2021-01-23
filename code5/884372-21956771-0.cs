    var dictionary = new Dictionary<Student, string>();
    var student = new Student { Name = "Jon", Age = 37 };
    dictionary[student] = "foo";
    Console.WriteLine(dictionary.ContainsKey(student)); // True
    dictionary.Name = "Bob";
    Console.WriteLine(dictionary.ContainsKey(student)); // False
    Console.WriteLine(dictionary.Keys.First() == student); // True!
