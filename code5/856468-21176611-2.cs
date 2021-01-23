    public async Task<ApplicationUser> FindByEMailAsync(String email)
    {
        var context = base.Context;
        String commandText = "Select * from AspNetUsers Where EMail = @email";
        var query = context.Database.SqlQuery<ApplicationUser>(commandText, new SqlParameter("@email",email));
        var data = await query.ToListAsync();
        return data.First();
    }
