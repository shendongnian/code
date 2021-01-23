    You can use linq for this as i have used    
  
    protected void ClickMeButton_Click(object sender, EventArgs e)
            {
                HtmlNode dt;
                DataSet sampleDataSet = new DataSet();
                sampleDataSet.Locale = CultureInfo.InvariantCulture;
                DataTable sampleDataTable = sampleDataSet.Tables.Add("SampleData");
                DataTable ErrorDataTable = sampleDataSet.Tables.Add("ErrorData");
                DataRow sampleDataRow;
                DataRow sampleErrorRow;
                var inputPath = "";
                //int numberSelected = lstAddItems.SelectedItems.Count;
    
                //Add path one by one:
                int flag = 0;
                ArrayList ar = new ArrayList();
                ArrayList storeIndex = new ArrayList();
    
                using (WebClient client = new WebClient())
                {
                    string pixarHtml = client.DownloadString("http://localhost:51450/20001.html");
    
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(pixarHtml);
    
                    HtmlNode pixarDiv = (from d in document.DocumentNode.Descendants()
                                         where d.Name == "div" && d.Attributes["id"].Value == "wrapper"
                                         select d).First();
    
                    HtmlNode pixarTable1 = (from d in document.DocumentNode.Descendants()
                                            where d.Name == "div" && d.Attributes["id"].Value == "data-review"
                                            select d).First();
    
                    IEnumerable<HtmlNode> pixarRows = (from d in pixarTable1.Descendants() where d.Name == "dl" && d.Attributes["class"].Value == "clearfix" select d);
                    //HtmlNode pixarTable = (from d in pixarDiv.Descendants() where d.Name == "table" select d).First();
                    //IEnumerable<HtmlNode> pixarRows = (from d in pixarDiv.Descendants() where d.Name == "dl" && d.Attributes["class"]!=null && d.Attributes["class"].Value == "clearfix" select d);
                    //IEnumerable<HtmlNode> columns;
                    IEnumerable<HtmlNode> columns;
                    String sth = "<table><tr><thead>";
                    String std = "<tbody><tr>";
    
                    foreach (HtmlNode row in pixarRows)
                    {
                        if (row.ChildNodes != null)
                        {
                            if (row.ChildNodes["dd"] != null)
                            {
                                sth += "<th>" + row.ChildNodes["dt"].InnerText.Trim() + "</th>";
                                if (row.ChildNodes["dt"] != null)
                                {
                                    std += "<td>" + row.ChildNodes["dd"].InnerText.Trim() + "</td>";
                                }
                                else
                                {
                                    std += "<td></td>";
                                }
                            }
                        }
                    }
                    std += "</tr></tbody>";
                    sth += "</thead></tr>" + std + "</table>";
                    var arr = Encoding.ASCII.GetBytes(sth);
                    File.WriteAllBytes("D:\\Demo14.xls", arr);
                }
            } 
