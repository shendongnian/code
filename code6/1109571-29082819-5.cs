    using (var prop = new ComObj<type>(obj.Property))
    {
        using (var propArray = new ComObj<type>(prop.ComObj[0]))
        {
            using (var propArrayReturn = new ComPtr<type>(propArray.ComObj.MethodThatReturnsAnotherObject()))
            {
            }
        }
    }
