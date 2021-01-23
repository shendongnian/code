            string playerStats = "D:\\playerStats.csv";
            string lineToDelete = listBox1.SelectedItem.ToString();
            if (File.Exists(playerStats))
            {
                string[] lines = File.ReadAllLines(playerStats);
                using (StreamWriter sw = new StreamWriter(playerStats, false))
                {
                    foreach (var line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts[0] != lineToDelete)
                        {
                            sw.WriteLine(line);
                        }
                        else
                        {
                            MessageBox.Show("Player: " + lineToDelete + "Has been deleted");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("playerStats.csv does not exist, Check Filepath");
            }
