    protected void Page_Load(object sender, EventArgs e)
    {
        btnChooseFile.Attributes.Add("onclick", "jQuery('#" + fuUploadPhoto.ClientID + "').click();return false;");
       //MultiViewAddPhoto.SetActiveView(viewAddPhotoStepOne);
    }
