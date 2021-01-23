    using (System.IO.StreamReader file = new System.IO.StreamReader(path))
    {
       while ((line = file.ReadLine()) != null)
       {
           Regex rgx = new Regex(pattern);
           Match m = rgx.Match(line);
           if (m.Success)
           {
               string result = string.Format("{0} {1} {2:D2}", m.Groups[3].Value, m.Groups[2].Value, Int32.Parse(m.Groups[1].Value));
               all += line.Replace(m.Value, result) + "\r\n";
               richTextBox1.Text += line.Replace(m.Value, result) + "\r\n";
           }
           else
           {
               all += line + "\r\n"; 
               richTextBox1.Text += line + "\r\n";
           }
       }
       file.Close();
    }
