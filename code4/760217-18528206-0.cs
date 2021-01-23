    public MemberBasicData GetMemberProfile(int id)
    {
        using (var con = new SqlConnection(Config.ConnectionString))
        {
            return con.Query<MemberBasicData>(
                "SELECT * FROM Mem_Basic WHERE Id=@id",
                new { id } // full parameterization, done the easy way
            ).FirstOrDefault();
        }
    }
