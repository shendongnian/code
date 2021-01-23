    Grades.Add(new Grade() { Name = "Grade 1", Prop = 1 });
    Grades.Add(new Grade() { Name = "Grade 2", Prop = 2 });
    People.Add(new Person() { Name = "guy 1", MyGrade = Grades[0] });
    People.Add(new Person() { Name = "guy 2", MyGrade = Grades[0] });
    People.Add(new Person() { Name = "guy 3", MyGrade = Grades[1] });
