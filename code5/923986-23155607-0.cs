    public KupacAdapter()
    {
        
    }
    public static List<Kupac> VratiKupce(int kriterijumPretrage, string tekstPretrage)
    {
        List<Kupac> listaKupaca = new List<Kupac>();
        SqlConnection konekcija = new SqlConnection();
        try
        {
            konekcija.ConnectionString = CONNECTION_STRING;
            konekcija.Open();
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            string selectUpit = "select * from Kupac where 1=1 ";
            if (!string.IsNullOrEmpty(tekstPretrage))
            {
                switch (kriterijumPretrage)
                {
                    case 0:
                        selectUpit += " and IdentifikacioniBroj LIKE '%' + @kriterijum + '%'";
                        break;
                    case 1:
                        selectUpit += " and Ime LIKE '%' + @kriterijum + '%'";
                        break;
                    case 2:
                        selectUpit += " and Prezime LIKE '%' + @kriterijum + '%'";
                        break;
                }
                komanda.Parameters.AddWithValue("@kriterijum", tekstPretrage);
            }
            komanda.CommandText = selectUpit;
            SqlDataReader reader = komanda.ExecuteReader();
            while (reader.Read())
            {
                listaKupaca.Add(new Kupac(reader));
            }
            reader.Close();
            return listaKupaca;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            konekcija.Close();
        }
    }
    public static void InsertKupac(Kupac kupac)
    {
        SqlConnection konekcija = new SqlConnection();
        try
        {
            konekcija.ConnectionString = CONNECTION_STRING;
            konekcija.Open();
            string insertUpit = "INSERT INTO Kupac(Ime, Prezime, IdentifikacioniBroj, ClanOd, KorisnickoIme) "
                                + "VALUES(@Ime, @Prezime, @IdentifikacioniBroj, GETDATE(), @KorisnickoIme)";
            SqlCommand komanda = new SqlCommand(insertUpit, konekcija);
            komanda.Parameters.AddWithValue("@Ime", kupac.Ime);
            komanda.Parameters.AddWithValue("@Prezime", kupac.Prezime);
            komanda.Parameters.AddWithValue("@IdentifikacioniBroj", kupac.IdentifikacioniBroj);
            komanda.Parameters.AddWithValue("@KorisnickoIme", kupac.KorisnickoIme);
            komanda.ExecuteNonQuery();
        }
        catch
        {
        }
        finally
        {
            konekcija.Close();
        }
    }
    public static void UpdateKupac(Kupac kupac)
    {
        SqlConnection konekcija = new SqlConnection();
        try
        {
            konekcija.ConnectionString = CONNECTION_STRING;
            konekcija.Open();
            string updateUpit = @" UPDATE [Kupac] 
                                   SET [Ime] = @Ime, [Prezime] = @Prezime, 
                        [IdentifikacioniBroj] = @IdentifikacioniBroj
                                   WHERE [KupacId] = @KupacId";
            SqlCommand komanda = new SqlCommand(updateUpit, konekcija);
            komanda.Parameters.Add("@Ime", kupac.Ime);
            komanda.Parameters.Add("@Prezime", kupac.Prezime);
            komanda.Parameters.Add("@IdentifikacioniBroj", kupac.IdentifikacioniBroj);
            komanda.Parameters.Add("@KupacId", kupac.KupacId);
            komanda.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            konekcija.Close();
        }
    }
    public static void DeleteKupac(Kupac kupac)
    {
        SqlConnection konekcija = new SqlConnection();
        try
        {
            konekcija.ConnectionString = CONNECTION_STRING;
            konekcija.Open();
            string deleteUpit = @" DELETE 
                                   FROM Kupac
                                   WHERE KupacId = @KupacId";
            SqlCommand komanda = new SqlCommand(deleteUpit, konekcija);
            komanda.Parameters.Add("@KupacId", kupac.KupacId);
            komanda.ExecuteNonQuery();
        }
        catch
        {
        }
        finally
        {
            konekcija.Close();
        }
    }
    public static DataTable VratiSveKupce()
    {
        DataTable dtSviKupci = new DataTable();
        SqlConnection konekcija = new SqlConnection();
        try
        {
            konekcija.ConnectionString = CONNECTION_STRING;
            konekcija.Open();
            string selectUpit = @"SELECT        KupacId, Ime, Prezime, IdentifikacioniBroj, ClanOd,
                                Ime + ' ' + Prezime + ' - ' + IdentifikacioniBroj AS PunoIme
                                FROM            Kupac
                                Order by Ime, Prezime, IdentifikacioniBroj";
            SqlDataAdapter da = new SqlDataAdapter(selectUpit, konekcija);
            da.Fill(dtSviKupci);
        }
        catch
        {
            dtSviKupci = null;
        }
        finally
        {
            konekcija.Close();
        }
        return dtSviKupci;
    }
    public static int VratiKupacIdZaKorisnickoIme(string korisnickoIme)
    {
        SqlConnection konekcija = new SqlConnection();
        try
        {
            konekcija.ConnectionString = CONNECTION_STRING;
            konekcija.Open();
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            string selectUpit = "select * from Kupac where KorisnickoIme=@KorisnickoIme";
            komanda.Parameters.AddWithValue("@KorisnickoIme", korisnickoIme);
            komanda.CommandText = selectUpit;
            return Convert.ToInt32(komanda.ExecuteScalar());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            konekcija.Close();
        }
    }
}
