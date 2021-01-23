    interface IConfigReader{
       object GetValue(string key);
    }
    // later in code
    var configDate = _reader.GetValue("ConnectionString");
