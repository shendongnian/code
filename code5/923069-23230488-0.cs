    public FileResult Thumbnail(int id)
    {
        var person = new People(GeneralSettings.DataBaseConnection).SelectById(id);
        return File(person.Thumbnail, System.Net.Mime.MediaTypeNames.Image.Jpeg);
    }
