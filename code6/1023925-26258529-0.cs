    public JsonResult GetProfileInformationViewModel(int id)
    {
        var myProfile = GetProfile(id);
        return new JsonResult(){ Data = myProfile };
    }
