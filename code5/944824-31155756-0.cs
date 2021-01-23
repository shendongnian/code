     protected void OnLnkUpload_Click(object sender, EventArgs e)
      {
                filename = Path.GetFileName(fileUpload1.PostedFile.FileName);
               fileUpload1.SaveAs(Server.MapPath("~/Files/" + filename));
                Response.Write("File uploaded sucessfully.");
                lblFilename.Text = "Files/" + fileUpload1.FileName;
      }
