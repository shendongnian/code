    public List<T> SearchByCodeType(ECodes codeType, List<T> list)
    {
        return list.Where((_item, _index) => _item.CodeType == codeType).ToList();
    }
    public List<T> SearchByCodeType(ECodes codeType, List<T> list)
    {
        return list.Where(_item => _item.CodeType == codeType).ToList();
    }
