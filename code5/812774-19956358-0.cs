    public List<ORDRE> Get_Ordre_ParDate_Iquery(string sql_SelectAll,
        DateTime dateDeb, DateTime dateFin)
    {
        using (var connectionWrapper = new Connexion())
        {
            connectionWrapper.GetConnected();
            return connectionWrapper.conn.Query<ORDRE>(sql_SelectAll,
                new { DATE_CREE_DEB = dateDeb, DATE_CREE_FIN = dateFin }).ToList()
        }
    }
