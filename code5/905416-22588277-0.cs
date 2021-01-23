    public class FolderUpdate
    {
        .... 
    }
    
    
    public FolderUpdate Folders { get; set; }
    
    private void btnTemBrow_Click(object sender, EventArgs e)
    {
         ...
         Folders.SwTemplate = tempText;
    }
    
    private void btnDirBrow_Click(object sender, EventArgs e)
    {
         ...
         Folders.SwDir = dirText;
    }
    
    
    // Then when you are reading them
    var folders = swSheetFormatCycle.Form1.Folders;
    string swDir = folders.SwDir;
    string swTemplate = folders.SwTemplate;
