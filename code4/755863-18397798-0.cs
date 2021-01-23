    public FilePathResult  ImageRetrive(int imgname)
    {
        string keyword=image.ToString();
        string imagefolderpath = Server.MapPath("~/Content/Member/MemberPhotos");
        string currentimage  = new Member().GetImage(imagefolderpath,keyword);
        string fullpath = "~/Content/Member/MemberPhotos/" + currentimage;
		return File(fullpath, "image/png"); //Changed here
    }
