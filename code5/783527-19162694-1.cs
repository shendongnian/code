    public static bool InsertMemberUsername(RegisterRequest register, Guid id_fk)
    {
        if (Exist(register.UserName.Username))
        {
            return false;
        }
        MEMBER_USERNAME entityToCreate = CreateMemberUsername(register, id_fk);
        MEMBER_USERNAME_DAL.SQLAtlInsert(entityToCreate, "Server=ConnSting Here;");
        return true;
    }
    
