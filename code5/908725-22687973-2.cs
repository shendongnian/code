    public void CompareMyObjects(object object1, object object2)
    {
        var type1Fields = object1.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
        var type2Fields = object2.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
    
        var propsInCommon = type1Fields.Join(type2Fields, t1 => t1.Name, t2 => t2.Name, (t1, t2) => new { frstGetter = t1.GetGetMethod(), scndGetter = t2.GetGetMethod() });
    
        foreach (var prop in propsInCommon)
        {
            Assert.AreEqual(prop.frstGetter.Invoke(object1, null), prop.scndGetter.Invoke(object2, null));
        }
    }
