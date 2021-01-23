    CsvGen csvGen=new CsvGen(@"C:\\temp\myFile.csv"); 
    // ^ any location with proper permission for .net to write files.
    public void AddStudent(int id, string name, string city)
    {
       Student stud=new Student();
       stud.Id=id;
       stud.Name=name;
       stud.City=city;
       csvGen.Add(stud);     
    }
