    private void openfile_Click(object sender, EventArgs e) {
        if (text.Text == String.Empty) {
            err.SetError(text, "Needs to contain Text");
        }
        DialogResult result = open_dialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            try
            {
                string file_name = open_dialog.FileName;
                System.IO.StreamReader sr = new System.IO.StreamReader(file_name);
                String line;
                List<string> wordslist=new List<string>(count);
                using (StreamReader reader = File.OpenText(file_name))
                {
                    // read each line, ensuring not null (EOF)
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != String.Empty) {
                            // Here instead of replacing array with new content
                            // we add new words to already existing list of strings
                            wordslist.AddRange(line.Split(' '));
                            count += 1;
                        }
                    }
                }
                // Count instead of Length because we're using List<T> now
                for (int i=0;i<wordslist.Count;i++)
                {
                    Console.WriteLine("\ncapacity " + wordslist[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nERROR= " + ex);
            }
        }
    }
