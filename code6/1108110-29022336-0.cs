    foreach (var teacher in context.Teachers)
    {
        Console.WriteLine("The teacher '{0}' is teaching the following classes:", 
            teacher.Name);
        foreach (var teacherClass in teacher.Classes)
        {
            Console.WriteLine(" - {0} ({1} students)", 
                teacherClass.Name, teacherClass.Students.Count);
        }
    }
