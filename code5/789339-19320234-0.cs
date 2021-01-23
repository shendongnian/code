    public static void StoreControl(this StateBag vs, Type controlType, string name)
    {
        var dynamicControls = vs["DynamicControls"] as List<Tuple<Type, string>>;
        if (dynamicControls == null)
        {
            dynamicControls = new List<Tuple<Type, string>>();
            vs["DynamicControls"] = dynamicControls;
        }
        var t = dynamicControls.FirstOrDefault(tp => tp.Item2 == name);
        if (t == null) { dynamicControls.Add(Tuple.Create(controlType, name)); }
    }
