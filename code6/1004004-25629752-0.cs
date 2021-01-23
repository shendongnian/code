    public List<Model> GetModels()
    {
        var listsizeCap = 3;
        var totalCount = Models.Count;
        if (totalCount > listsizeCap)
        {
            HttpContext.Current.Items["LabelToSet"] = string.Format("The grid only shows the first {0} results of a total of {1}", listsizeCap, totalCount);
        }
        return Models.Take(listsizeCap).ToList();
    }
