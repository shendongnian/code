    public string ItemName
    {
        get
        {
            return string.Join("/",
                Ancestors.Reverse().Select(category => category.Name));
        }
    }
