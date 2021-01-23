     public void ConvertToTXTFile(string fileName)
     {
         StringBuilder sb = new StringBuilder();
         System.Text.Encoding Output = System.Text.Encoding.Default;
         foreach (PersonInfos personinfos in PersonInfoDetails)
         {
             if (personinfos.SelectCheckBox == true)
             {
                string line = String.Format("L§" + personinfos.FirstName + "§" + personinfos.LastName + "§");
                sb.AppendLine(line);
             }
         }
         using(StreamWriter file = new StreamWriter(filename))
         {
             file.Write(sb.ToString());
         }
    }
