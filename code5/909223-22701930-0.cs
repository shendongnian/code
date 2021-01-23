            Regex Regex = new Regex("[^0-9.]");
            HtmlWeb client = new HtmlWeb();
            //Check Server version
            try
            {
                HtmlAgilityPack.HtmlDocument doc = client.Load("https://minecraft.net/download");
                HtmlNodeCollection Nodes = doc.DocumentNode.SelectNodes("//p//a[@href]");
                ServerVersion = Regex.Replace(Nodes[4].InnerText, String.Empty).Remove(0, 1).TrimEnd('.');
                BStripServerVersion.Text = ServerVersion + "  |";
                FileName = (Nodes[6].InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
