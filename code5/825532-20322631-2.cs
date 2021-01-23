    private void btn_parse_Click(object sender, EventArgs e)
    {
        string FileName = @"..\..\bin\Debug\htm\allaim.htm";
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.Load(FileName);
        HtmlNodeCollection tables = doc.DocumentNode.SelectNodes("//table");
        using(FileStream fs = new FileStream(@"..\..\bin\Debug\txt\" + "allaim.txt", FileMode.Append))
        using(StreamWriter sw = new StreamWriter(fs))
        {
            HtmlNodeCollection rows = tables[3].SelectNodes(".//tr");
            for (int i = 0; i < rows.Count; ++i)
            {
                HtmlNodeCollection cols = rows[i].SelectNodes(".//td[1]");
                HtmlNodeCollection cols2 = rows[i].SelectNodes(".//td[2]");
                for (int j = 0; j < cols.Count; ++j)
                    sw.WriteLine("'" + cols[j].InnerText + "','" + cols2[j].InnerText + "'");
            }
            sw.Flush();
            sw.Close();
            fs.Close();
            MessageBox.Show("Done writing!");
        }
    }
