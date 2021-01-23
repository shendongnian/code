    var values = new Dictionary<string, object>();
    IEnumerable<string> keys = ViewBag.GetDynamicMemberNames();
    foreach (string key in keys)
    {
        var binder = Microsoft.CSharp.RuntimeBinder.Binder.GetMember(
            CSharpBinderFlags.None, key, 
            ViewBag.GetType(),
            new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
        var callsite = CallSite<Func<CallSite, object, object>>.Create(binder);
        var val = callsite.Target(callsite, ViewBag);
        values.Add(key, val);
    }
