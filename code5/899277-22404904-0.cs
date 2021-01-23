    protected void btnDownload_Click(object sender, EventArgs e)
    {        
         lblresume.Text = "~/Student_Resume/" + fuResume.FileName.ToString();         
         if (lblresume.Text != string.Empty)        
         {
             string filePath = lblresume.Text;             
             Response.ContentType = "doc/docx";             
             Response.AddHeader("Content-Disposition", "attachment;filename=\"" + fuResume.FileName.ToString() + "\"");              
             Response.TransmitFile(Server.MapPath(filePath));             
             Response.End();         
         }    
    }
