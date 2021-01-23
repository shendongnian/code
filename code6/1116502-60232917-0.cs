    public async Task<ActionResult> ResetUserPassword(string id, string Password)
    {
        //     Find User
        var user = await context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
        if (user == null)
        {
            return RedirectToAction("UserList");
        }
        await UserManager.RemovePasswordAsync(id);
        //     Add a user password only if one does not already exist
        await UserManager.AddPasswordAsync(id, Password);
        return RedirectToAction("UserDetail", new { id = id });
    }
