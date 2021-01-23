    queryString = "UPDATE Scores SET PlayerName=?, [Level]=?, DamageReceived=? WHERE Pos=?";
    // ...
    command.Parameters.AddWithValue("?", PN);
    command.Parameters.Add("?", SqlDbType.Int).Value = lvl;
    command.Parameters.Add("?", SqlDbType.Int).Value = dmg;
    command.Parameters.Add("?", SqlDbType.Int).Value = plek;
