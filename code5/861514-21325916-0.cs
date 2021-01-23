    //You will likely need to modify the calling code to use async/await too.
    async Task FileDetected()
    {
        int counter = 0,c=1;
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader(FILEPATH);
        while ((line = file.ReadLine()) != null)
        {
            string[] words = line.Split('|');
            c = 1;
            path = ""; fileName = "";
            foreach (string word in words)
            {
                if (c == 1)
                    path = word.Replace(@"\\", @"\");
                if (c==2)
                    fileName = word;
                c++;
            }
            counter++;
            if (path != "" && fileName != "")
            {
                Console.WriteLine("Path :" + path);
                Console.WriteLine("FileName: " + fileName);
                popup dlg = new popup(path, fileName);
                dlg.Show();
                //Pauses the loop for 10 sec but does not lock up the UI.
                await Task.Delay(10000);
            }
        }
