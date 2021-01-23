    public class PDFFileSave : AbstractFileSave {
      public PDFFileSave(string filePath) : base(filePath) {}
      
      protected override bool OnSaveFile(string filePath) {
        // for simulating a long running process
        // Thread.Sleep(5000);
        // write save pdf file operation here
        File.WriteAllText(filePath, "Some PDF contents");
        // try returning false instead to simulate an error in saving file
        // return false;
        return File.Exists(filePath);
      }
    }
