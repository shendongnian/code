    public string sFunc(string sCol , int iId)
    {
      var row = TableRepository.Entities.Where(x => x.ID == iId);
      var type = typeof(row);
      var propInfo = type.GetProperty(sCol);
      if (propInfo != null)
      {
        string value = (string)propInfo.GetValue(row);
        return value;
      }
      return null;
    }
