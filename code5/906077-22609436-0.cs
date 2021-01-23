       protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                fup.SaveAs(Server.MapPath("~/192.zzz.zzz.z/CaheadServices/Images" + fup.FileName));
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            } 
    
        }
