          string txtBatFile= "<physical path for batfile>";
            if (File.Exists(txtBatFile))
            {
                     StreamReader SR = new StreamReader(txtBatFile);
                     string strFileText= SR.ReadToEnd();
                     SR.Close();
                     SR.Dispose();
        
            string pattern = @"=(?<after>\w+)";        
    
          MatchCollection matches = Regex.Matches(strFileText, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        
            ArrayList _strList = new ArrayList();
            foreach (Match match in matches)
           {
            _strList.Add(match.Groups["after"].ToString());
           }
        
            Textbox1.Text = _strList[0].ToString();
            Textbox2.Text = _strList[1].ToString();
            Textbox3.Text = _strList[2].ToString();
            Textbox4.Text = _strList[3].ToString();
            }
