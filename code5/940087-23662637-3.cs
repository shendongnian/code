    // Create Our List
    List<Student> student = new List<Student>();
    
    // Add our Students to the List
    student.Add(new Student() { Name = "Greg", Score = 100, Grade = "A+" });
    student.Add(new Student() { Name = "Kelli", Score = 32, Grade = "F" });
    student.Add(new Student() { Name = "Jon", Score = 95, Grade = "A" });
    student.Add(new Student() { Name = "Tina", Score = 93, Grade = "A-" });
    student.Add(new Student() { Name = "Erik", Score = 82, Grade = "B" });
    student.Add(new Student() { Name = "Ashley", Score = 75, Grade = "C" });
    
    // Apply our Sort.
    student.Sort();
    
    // Loop through Our List:
    foreach (Student placement in student)
         listBox1.Items.Add(placement.Name + " " + placement.Score + " " + placement.Grade);
