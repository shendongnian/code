            StreamWriter writer;
            try
            {
                writer = new StreamWriter(fileName);
            }
            catch
            {
                MessageBox.Show("Error, could not open " + fileName + " for saving");
            }
            try 
            {
                foreach (string entry in playerArray)
                {
                    writer.WriteLine(entry);
                }
            }
            catch
            {
                MessageBox.Show("Couldn't save");
            }
            writer.Close();
