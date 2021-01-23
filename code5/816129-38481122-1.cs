    public JsonResult DeletePersonRole(int personId, PersonRoleEnum roles)
    {
        // do business logic here...
        // roles will now have value PersonRoleEnum.User|PersonRoleEnum.Student
        // and you can use roles.HasFlag(PersonRoleEnum.User) to check if that flag is set
        return Json(new {Result = "OK"});
    }
