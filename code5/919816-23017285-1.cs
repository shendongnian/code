     public void ConvertToTXTFile(string fileName)
     {
         StringBuilder sb = new StringBuilder();
         System.Text.Encoding Output = System.Text.Encoding.Default;
         foreach (PersonInfos personinfos in PersonInfoDetails)
         {
             // Collect every personinfos selected in the stringbuilder
             if (personinfos.SelectCheckBox == true)
             {
                string line = String.Format("L§" + personinfos.FirstName + "§" + personinfos.LastName + "§");
                sb.AppendLine(line);
             }
         }
         // Now write the content of the StringBuilder all together to the output file
         File.WriteAllText(filename, sb.ToString())
    }
