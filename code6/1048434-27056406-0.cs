    protected void lnkStart_Click(object sender, EventArgs e)  // Link Button Click Event
    {
        imgRefresher.Enabled = true; // setting Timer Control Enabled to 1
        Session["TimerEnabled"] = imgRefresher.Enabled; // storing 1 in Session
        Session["FileName"] = "myFile.exe";
    }
    protected void imgRefresher_Tick(object sender, EventArgs e) // Timer Control Tick Event
    {
        if (Session["TimerEnabled"]) // This line gives me an invalid cast error
        {
            Session["TimerEnabled"] = false;
            string fileName = Session["FileName"].ToString();
            // This part I stole off the internet and will actually open the file.
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(fileInfo.FullName);
                Response.End();
            }
        }
        imgRefresher.Enabled = false;
    }
