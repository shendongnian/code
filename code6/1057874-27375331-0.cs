        int index;
        if (_sqlreader.HasRows)
        {
          index = _sqlreader.GetOrdinal("ColumnName");
          if (!_sqlreader.IsDBNull(index))
            return _sqlreader.GetInt32(index);
        }
      
