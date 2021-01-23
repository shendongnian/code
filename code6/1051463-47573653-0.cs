        <script language="c#" runat="server">
            protected void Button1_Click1(object sender, EventArgs e)
            {
    string k="file full path 'eg: http://something.com/test.pdf' ";
                Response.ContentType = "Application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Test_PDF.pdf");
    
                WebClient wc = new WebClient();
                byte[] myDataBuffer = wc.DownloadData(k);
                Response.BinaryWrite(myDataBuffer);
                Response.End();
            }
        </script>
