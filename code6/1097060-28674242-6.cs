    List<Student> students = new List<Student>()
    do
    {
         Console.Write("Please enter the Name of the Student(enter \"finish\" to  exit):");
         string name = Console.ReadLine();
         if(name.ToLower() == "finish" )
             break;
         bool validMark = false;
         do
         {
             Console.Write("Please enter the Mark of {0}:", name);
             string markString = Console.ReadLine();
             int mark;
             validMark = int.TryParse(markString,out mark);
             if(!validMark)
                 Console.WriteLine("Invalid Number Entered");
             else
                 students.Add(new Student{Name=name, Mark = mark});
         } while (!validMark)
     } while (true)
