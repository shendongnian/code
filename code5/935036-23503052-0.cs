    using(OleDbConnection _connectMe = Utilities.OledbConnect())
    using(OleDbCommand _query1 = _connectMe.CreateCommand())
    {
        _query1.CommandText = "SELECT count(*) FROM GIS.PERSONS where Name_Prefix = 'Dr.'";
        _connectMe.Open();
        int _value = (int)_query1.ExecuteScalar();
    }
