    using System.IO;
       
    private void WriteFileContentsToTextBox(string filePath)
    {
         // Always check for existence of the file
         if (File.Exists(filePath))
         {
            // Open the file to read from. 
            string[] readText = File.ReadAllLines(filePath, Encoding.UTF8);
            myMultilineTextBox.Text = string.Join(Environment.Newline, readText);
         }
     }     
 
        
