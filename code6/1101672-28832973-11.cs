    protected void SaveButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in ImagesGrid.Rows)
        {
            var title = row.FindControl("txtTitle") as TextBox;
            var description = row.FindControl("txtDescription") as TextBox;
            var imageFile = row.FindControl("flUpload") as FileUpload;
            string filename = Path.GetFileName(imageFile.FileName);
            imageFile.SaveAs(Server.MapPath("/GalleryImages/" + filename));
            //TO DO: write save routine
        }
    }
