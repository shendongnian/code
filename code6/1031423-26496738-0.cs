    protected void Page_Load(object sender, EventArgs e)
        {
            string outputFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName(), ".pdf");
            string args = string.Format("\"{0}\" \"{1}\"", Request.Form["url"], outputFile );
            var startInfo = new ProcessStartInfo(Server.MapPath("\\tools\\wkhtmltopdf.exe"), args)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            var proc = new Process { StartInfo = startInfo };
            proc.Start();
    
            proc.WaitForExit();
            proc.Close();
    
            var buffer= File.ReadAllBytes(outputFile);
            File.Delete(outputFile);
    
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=test.pdf");
            Response.BinaryWrite(buffer);
            Response.End();
        }
