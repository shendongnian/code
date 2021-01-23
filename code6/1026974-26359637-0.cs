    public FileContentResult GetImage(int itemId)
    {
    UserProfile user = db.userProfiles.FirstOrDefault(u => u.Id.Equals(itemId));
    if(user != null)
    return File(user.Image, user.ImageMimeType);
    else return null;
    }
