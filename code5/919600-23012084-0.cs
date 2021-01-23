    public int? SubBrandIndex
    {
        get
        {
            int? subBrandIndex = null;
            if (_model.SubBrand != null)
                subBrandIndex = int.Parse(_model.SubBrand);
            return subBrandIndex;
        }
    }
