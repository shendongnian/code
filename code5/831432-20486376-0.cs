    protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = getHTML(GridView1);
        }
    
        private string getHTML(GridView gv) 
        { 
            StringBuilder sb = new StringBuilder(); 
            StringWriter textwriter = new StringWriter(sb); 
            HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter); 
            gv.RenderControl(htmlwriter); 
            htmlwriter.Flush(); 
            textwriter.Flush(); 
            htmlwriter.Dispose(); 
            textwriter.Dispose(); 
            return sb.ToString(); 
        }
