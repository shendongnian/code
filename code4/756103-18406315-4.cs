    var assembly = Assembly.LoadFrom("//path");
    Type type = assembly.GetType("TestFrameWork.University");
    var Uni = Activator.CreateInstance(type); 
    type = assembly.GetType("TestFrameWork.Student");
    var student = Activator.CreateInstance(type); 
    student.University = Uni;
    
