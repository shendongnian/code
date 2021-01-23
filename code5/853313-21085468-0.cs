    public int sFunc(string sCol, int iId)
    {
        var _tableRepository = TableRepository.Entities.Where(x => x.ID == iId).Select(e => e).FirstOrDefault();
        if (_tableRepository == null) return 0;
        var _value = _tableRepository.GetType().GetProperties().Where(a => a.Name == sCol).Select(p => p.GetValue(_tableRepository, null)).FirstOrDefault();
        return _value != null ? Convert.ToInt32(_value.ToString()) : 0;
    }
