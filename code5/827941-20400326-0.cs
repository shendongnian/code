    UITestControl nameoffunctionweneed(string path)
    {
        object res = UIMap;
        foreach (var item in path.Split('.'))
        {
            res = res.GetType().GetProperty(item).GetValue(res, null);
        }
        return res as UITestControl;
    }
