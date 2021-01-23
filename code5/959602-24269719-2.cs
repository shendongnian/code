       void DragDropRichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileText = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fileText != null)
            {
                foreach (string name in fileText)
                {
                    try
                    {
                        // Read each file using the helper class rather than File.ReadAllText
                        // then append the end-of-file line
                        this.AppendText(BinaryFile.ReadString("your_file_name.txt") 
                            + "\n -------- End of File -------- \n\n");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);  
                    }
                }
            }
        }
