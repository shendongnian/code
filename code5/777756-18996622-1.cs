    string[] filesPath = Directory.GetFiles(Server.MapPath("~/download_results/"));
    
    foreach (string fileName in filesPath)
            {
                string file = Path.GetFileName(fileName);
                Panel1.Controls.Add(new LiteralControl("<div>"));
                HyperLink hl = new HyperLink();
                hl.Text = file;
                hl.ID = file;
                hl.Target = "_blank";
                hl.NavigateUrl = "http://www.bbb.co/download_results/" + file;
                Panel1.Controls.Add(hl);
                Panel1.Controls.Add(new LiteralControl("</div>"));
            }
