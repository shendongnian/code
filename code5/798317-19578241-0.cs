            List<int> toRemove = new List<int>();
            int i = 0;
            /*build a list of indexes to remove*/
            foreach (string[] x in deleteDevice)
            {
                if (x[0].Contains(deviceList.SelectedItem.ToString()))
                {
                    toRemove.Add(i);
                }
                i++;
            }
            /*Remove items from list*/
            foreach (int fd in toRemove)
                 deleteDevice.RemoveAt(fd);
                
            /*write to text file*/
            using (StreamWriter writer = new StreamWriter("Devices.txt"))
            {
                if (deleteDevice.Count != 0) //Error Handling
                {
                    foreach (string[] s in deleteDevice)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int fds = 0; fds < s.Length; fds++ )
                        {
                           sb.Append(s[fds] + ",");
                        }
                        string line = sb.ToString();
                        writer.WriteLine(line.Substring(0, line.Length - 1));
                    }
                }
            }
