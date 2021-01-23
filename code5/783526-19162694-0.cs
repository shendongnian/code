    public static void InsertMemberUsername(RegisterRequest register, Guid id_fk)
    {
        if (Exist(register.UserName.Username))
        {
            // display error message to pick some other username
        }
        MEMBER_USERNAME entityToCreate = CreateMemberUsername(register, id_fk);
        MEMBER_USERNAME_DAL.SQLAtlInsert(entityToCreate, "Server=ConnSting Here;");
    }
