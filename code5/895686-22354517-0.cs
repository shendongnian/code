     using SourceSafeTypeLib;
     VSSDatabaseClass vssDatabase = new VSSDatabaseClass();
     vssDatabase.Open("VSS database path", "userName", "password");
     VSSItem item = vssDatabase.get_VSSItem("file path as shown in vss", false);
     item.Checkout("Comments", item.LocalSpec, 0);
     using (StreamWriter sw = File.AppendText(lblSourceFile.Text))
     {
         sw.WriteLine("text");
     }
     item.Checkin("Comments", item.LocalSpec, 0);
     vssDatabase.Close();
