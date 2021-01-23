    private static object GetPropertyValue(object obj, string propertyName)
    {
        return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
    }
    public List<TB_PRODUTO> GetAll(int ID_Empresa, String Order)
    {
        return Ent.TB_PRODUTO.Where(x => x.ID_EMPRESA == ID_Empresa).Select(x => x).OrderBy(x => GetPropertyValue(x, Order)).ToList();
    }
