       string searchfor = textBox1.Text
        Assembly assm = Assembly.GetExecutingAssembly();
        using (Stream datastream = assm.GetManifestResourceStream("WindowsFormsApplication2.Resources.file1.txt"))
        using (StreamReader reader = new StreamReader(datastream))
        {
            string lines;
            while ((lines = reader.ReadLine()) != null)
            {
                if (lines.StartsWith(searchfor))
                {
                    label1.Text = "Found";
                    break;
                }
                else
                {
                    label1.Text = "Not found";
                }
            }
        }
