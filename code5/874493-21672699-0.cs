    string sourceLocation = textBox2.Text;
    string dstnLocation = string.Format(@"C:\Fldr\Docs\{0}", Path.GetFileName(sourceLocation);
    if (! System.IO.Directory.Exists(dstnLocation))
    {
          System.IO.Directory.Create(dstnLocation);
    }
 
    System.IO.File.Copy(sourceLocation, dstnLocation,true);
    MessageBox.Show("Download Complete");
