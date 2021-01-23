    private void read1()
    {
        using (var fs = new FileStream(@"T:\testfile", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
            using (var tr = new StreamReader(fs)) {
                string input = null;
                while ((input = tr.ReadLine()) != null)
                {
                    if (input.Contains("test"))
                    {
                        MessageBox.Show(input);
                    }
                }
            }
        }    
    }
