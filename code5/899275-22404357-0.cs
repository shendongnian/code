    protected void btnDownload_Click(object sender, EventArgs e)
    {        
         lblresume.Text = "~/Student_Resume/" + fuResume.FileName.ToString();         
         if (lblresume.Text != string.Empty)        
         {
             WebClient req = new WebClient();
             HttpResponse response = HttpContext.Current.Response;
             string filePath = lblresume.Text;               
             response.Clear();
             response.ClearContent();
             response.ClearHeaders();
             response.Buffer = true;
             response.AddHeader("Content-Disposition", "attachment;filename=Filename.extension");
             byte[] data = req.DownloadData(filePath);
             response.BinaryWrite(data);
             response.End();                   
         }    
    }
    
                
