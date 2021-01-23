    try
    {
    int w = Convert.ToInt32(RegID.Text);
    byte[] image = null;
    {
    var photoRecord = (from accom in re.Students
                    where accom.RegistrationNo == w
                    select accom).First();
    image = photoRecord.Picture;
    string base64String = Convert.ToBase64String(image, 0, image.Length);
    picbox.ImageUrl = "data:image/png;base64," + base64String;
    }
    }
    catch (Exception)
    {
    throw;
    }
