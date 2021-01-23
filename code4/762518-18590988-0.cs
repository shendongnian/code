    StringBuilder query = new Stringbuilder();
    query.AppendLine("INSERT INTO zajsluz(akce,text,castka,rocnik) ");
    query.AppendLine("(SELECT @akce, text, castka, @rocnik");
    query.AppendLine("FROM zajsluz WHERE akce=@Tentoradek");
    query.AppendLine("AND rocnik=@rocnik)");
    SqlCommand sc2 = new SqlCommand(sqlcom2, spojeni);
    sc2.Parameters.AddWithValue("@Tentoradek", tentoradek);
    sc2.Parameters.AddWithValue("@akce", zakce.Text);
    sc2.Parameters.AddWithValue("@rocnik", klientClass.Rocnik());
    
    spojeni.Open();
    sc2.ExecuteNonQuery();
    spojeni.Close();
