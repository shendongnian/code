    using(var see = new MySqlCommand(
        "REPLACE INTO users (login, email) VALUES (?login,?email)",this.dbcontext))
    {
        MySqlParameter p1 = new MySqlParameter("login",MySqlDbType.VarChar,20);
        p1.Value = "Hello";
        MySqlParameter p2 = new MySqlParameter("email", "Dude");
        see.Parameters.Add(p1);
        see.Parameters.Add(p2);
        see.ExecuteNonQuery();
    }
