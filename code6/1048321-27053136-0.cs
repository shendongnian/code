     public void do_name1()
        {
            string old;
            string iniPath = Application.StartupPath + "\\list.ini";
            bool isDeleteSectionFound = false;
            List<string> deleteCodeList = new List<string>();
            using (StreamReader sr = File.OpenText(iniPath))
            {
                while ((old = sr.ReadLine()) != null)
                {
                    if (old.Trim().Equals("[DELETE]"))
                    {
                        isDeleteSectionFound = true;
                    }
                    if (isDeleteSectionFound && !old.Trim().Equals("[DELETE]"))
                    {
                        deleteCodeList.Add(old.Trim());
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = File.OpenText(textBox1.Text))
            {
                while ((old = sr.ReadLine()) != null)
                {
                    var st = old.Trim().Split(new char[] { '\t' });
                    if (st.Length > 1)
                    {
                        var tempCode1 = st[0].Substring(1, st[0].Length - 2);
                        if (!deleteCodeList.Contains(tempCode1)) 
                        {
                            sb.AppendLine(old);
                        }
                    }
                    else if (st.Length == 1)
                    {
                        //old = "\n";
                        sb.AppendLine(old);
                    }
                }
            }
            File.WriteAllText(textBox1.Text, sb.ToString());
        }
