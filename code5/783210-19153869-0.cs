     if (!(this.IsPostBack))
        {
            // For News DataList
            prepareConnection();
            _command.CommandText = "select top (5) ID ,Title,img,Contect from News ORDER BY id DESC";
    
            _adp = new SqlDataAdapter();
            _tbl = new System.Data.DataTable();
            _adp.SelectCommand = _command;
            _adp.Fill(_tbl);
            SqlDataReader DataReader = _command.ExecuteReader();
            DataReader.Read();
            Response.BinaryWrite((byte[])DataReader[2]);
            DataReader.Close();
            dlNews.DataSource = _tbl;
            dlNews.DataBind();
        }
