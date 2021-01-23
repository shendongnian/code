    public class CsvGen
    {
      private _fileName=string.Empty;
      private StringBuilder csvRows;
      public CsvGen(string fileName)
      {
        _fileName=fileName;
        csvRows=new StringBuilder();
      }
      
      public void Add(Student student)
      {
        var row=String.Format("{0},{1},{2},{3}",student.Id,student.Name,student.City,
                                                                     Environment.NewLine);
        csvRows.Append(row);
      }
      public void SaveFile()
      {
        System.IO.File.WriteAllText(_fileName,csvRows.ToString());
      }
    }
