    string content = "Jason rules";
    string filename = "file.txt";
    var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
    if (!Directory.Exists(documents))
    {
        Console.WriteLine("Directory does not exist.");
    }
    else
    {
        Console.WriteLine("Directory exists.");
        File.WriteAllText(documents + @"/" + filename, content);
        if (!File.Exists(documents + @"/" + filename))
        {
            Console.WriteLine("Document not found.");
        }
        else
        {
            string newContent = File.ReadAllText(documents + @"/" + filename);
            TextView viewer = FindViewById<TextView>(Resource.Id.textView1);
            if (viewer != null)
            {
                viewer.Text = newContent;
            }
        }
    }
