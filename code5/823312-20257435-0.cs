    using (StreamWriter sr = new StreamWriter(@"../../Archive/TextFileTotalEspecies.txt"))
        {
            foreach (List<int> list in TotalDeEspecies)
            {
                string s = String.Join("~", list.ConvertAll(i => i.ToString()).ToArray());
                sr.WriteLine(s);
            }
            sr.Close();
            File.AppendAllText(@"../../Archivos/TextFileTotalEspecies.txt", "End" + Environment.NewLine);
        }
