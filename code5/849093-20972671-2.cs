    public class TextFileSave : AbstractFileSave {
       public TextFileSave(string filePath) : base(filePath) { }
       protected override bool OnSaveFile(string filePath) {        
         // write save text file operation here
         File.WriteAllText(filePath, "Some TXT contents");                
	 
         return File.Exists(filePath);
       }
    }
