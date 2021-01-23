    string[] lines = File.ReadAllLines("D:\\A.txt");
    List<Student> list = new List<Student>();
    foreach (string line in lines)
    {
        string[] contents = line.Split(new char[] { ' ' });
        var student = new Student { ID = contents[0], Name = contents[1] };
        list.Add(student);
    }  
    using(FileStream fs = new FileStream("D:\\B.xml", FileMode.Create))
    {
        new XmlSerializer(typeof(List<Student>)).Serialize(fs, list);
    }
