    public string GetAllUsers()
    {
        objUserView.LstRole = objUserManager.GetAllRoles();
        objUserView.FirstName = "Test";
        objUserView.LastName = "Test 1";
        objUserView.UserID = 1;
        return JsonConvert.SerializeObject(objUserView.LstRole, Formatting.None, new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
}
