    public async Task<Dictionary<string,string>> GetSchedule_HC(string day, string week)
            {
                string year = "21"; //get from settings
                string semestre = "S1"; //get from settings
                string ciclo = "1"; //get from settings
                string course = "1408"; //get from settings
                string url = "https://academicos.ubi.pt/online/horarios.aspx?p=a";
                string cicleY = "1"; //get from settings
                
                
                string htmlPage;
                using(var wp = new HttpClient())
                {
                    htmlPage = await wp.GetStringAsync(new Uri(url));
                }
    
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlPage);
                Dictionary<string, string> rtnval = new Dictionary<string, string>();
                HtmlNodeCollection selectNode = htmlDoc.GetElementbyId("ContentPlaceHolder1_ddlAnoLect").ChildNodes;
                             
                foreach (HtmlNode optNode in selectNode)
                {                
                    if (optNode.Name == "option")
                    {
                        string txt = optNode.NextSibling.InnerText;
                        string val = optNode.Attributes["value"].Value;
                        rtnval.Add(val,txt);
                    }
                }
                   
               
    
                return rtnval;
            }
