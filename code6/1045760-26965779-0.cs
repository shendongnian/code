    using (var sqlCon = new SqlConnection(Context.ReturnDatabaseConnection()))
    {
        return sqlCon.Query<UserEmailEntity>
            (@"SELECT e.EmailId, e.ItemId, u.Username as FromUserName, e.EmailReceived
               FROM User_Emails e
               INNER JOIN User_Profile u on e.FromUserId = u.UserId
               WHERE ToUserId = @userId and EmailStatus = @Status",
               new { ToUserId = userId, Status = status })
            .OrderBy(d => d.EmailReceived)
            .Select(usrEmlEnt => usrEmlEnt.UserEmails);
    }
