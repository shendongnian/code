            string[] arr = { "linux", "windows", "linux", "linux", "windows", "mac os", "unix", "mac os" };
            string[] uniq = new string[0];
            string[] keys = new string[0];
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (uniq.Contains(arr[i]))
                {
                    continue;
                }
                else
                {
                    uniq = uniq.Concat(new string[] { arr[i] }).ToArray();
                    keys = keys.Concat(new string[] { i + "" }).ToArray();
                }
            }
            foreach (string key in keys)
            {
                textBox1.Append(key + "\r\n");
            }
