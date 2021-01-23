        public static void getPermText(System.Windows.Forms.Form targetForm)
        {
            Stream fileStream = File.Open(dataFolder + PermFile, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            string line = null;
                line = reader.ReadToEnd();
                string[] parts = line.Split('\n');
                try
                    {
                
                    int userCount;
                    userCount = parts.Length;
                    CheckBox[] chk = new CheckBox[userCount];
                    int height = 1;
                    int padding = 10;
                    for (int i = 0; i < userCount; i++)
                        {
                        chk[i] = new CheckBox();
                        chk[i].Name = parts[i];
                        chk[i].Text = parts[i];
                        chk[i].TabIndex = i;
                        chk[i].AutoCheck = true;
                        chk[i].Bounds = new Rectangle(15, 30 + padding + height, 150, 22);
                        targetForm.Controls.Add(chk[i]);
                        height += 22;
                        }
                    }
                catch
                    {
                    } 
              }
