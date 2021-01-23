    //Add table in the form load event
    private void Form1_Load(object sender, EventArgs e)
            {
                webbSPPagina.DocumentText = "<table id='table1'><tr><td>hello</td></tr></table>";
            }
    //Added your code in a button click event
     private void button1_Click(object sender, EventArgs e)
            {
                HtmlElement element = webbSPPagina.Document.GetElementById("table1");
                HtmlElement mTBody = element.FirstChild;
                HtmlElement mTR = webbSPPagina.Document.CreateElement("tr");
                HtmlElement mTD1 = webbSPPagina.Document.CreateElement("td");
                HtmlElement mTD2 = webbSPPagina.Document.CreateElement("td");
                HtmlElement mTD3 = webbSPPagina.Document.CreateElement("td");
    
                mTD1.Style = "VERTICAL-ALIGN: top";
                mTD2.Style = "VERTICAL-ALIGN: top";
                mTD3.Style = "VERTICAL-ALIGN: top";
                mTD1.SetAttribute("class", "ms-rtetablecells");
                mTD2.SetAttribute("class", "ms-rtetablecells");
                mTD3.SetAttribute("class", "ms-rtetablecells");
                mTD1.InnerText = "Teamviewer Id";
                mTD2.SetAttribute("id", "TeamviewerId");
                mTD3.SetAttribute("id", "TeamviewerIdExtra");
    
                mTR.AppendChild(mTD1);
                mTR.AppendChild(mTD2);
                mTR.AppendChild(mTD3);
                mTBody.AppendChild(mTR);
         
    //The following line is new. May be this is the major change
                webbSPPagina.DocumentText = mTBody.InnerHtml;
            }
