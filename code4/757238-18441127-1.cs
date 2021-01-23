    public class SimpleFileCopy
    {
     static void Main()
     {
        string fileName = "test.txt";
        string sourcePath = @"C:\Users\Public\TestFolder";
        string targetPath =  @"C:\Users\Public\TestFolder\SubDir";        
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);      
        System.IO.File.Copy(sourceFile, destFile, true);      
             
    }
}
