    private void btn_parse_Click(object sender, EventArgs e)
    {
        string FileName = @"..\..\bin\Debug\htm\allaim.htm";
    
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.Load(FileName);
    
            HtmlNodeCollection tables = doc.DocumentNode.SelectNodes("//table");
    
            HtmlNodeCollection rows = tables[3].SelectNodes(".//tr");
            for (int i = 0; i < rows.Count; ++i)
            {
                HtmlNodeCollection cols = rows[i].SelectNodes(".//td[1]");
                for (int j = 0; j < cols.Count; ++j)
                {
                    string value = cols[j].InnerText;
                    FileStream fs = new FileStream(@"..\..\bin\Debug\txt\" + "allaim.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(value + ",");//use Write() instead of WriteLine()
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
    
                HtmlNodeCollection cols2 = rows[i].SelectNodes(".//td[2]");
                for (int j = 0; j < cols2.Count; ++j)
                {
                    string value = cols2[j].InnerText;
                    FileStream fs = new FileStream(@"..\..\bin\Debug\txt\" + "allaim.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(value);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }   
            }
            MessageBox.Show("Done writing!");
        }
