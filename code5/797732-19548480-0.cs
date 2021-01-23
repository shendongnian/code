    var @this = new { a = 3, b = 4 };
    var other = new { a = 3, b = 4 };
    Func<object, object, bool> equalFn = Delegate.CreateDelegate(
      typeof(Func<object, object, bool>),
      typeof(object).GetMethod("Equals",
        System.Reflection.BindingFlags.Public |
        System.Reflection.BindingFlags.Instance)) as Func<object, object, bool>;
    equalFn.Invoke(@this, other); // call example
    equalFn.DynamicInvoke(new[] { @this, other }); // apply example
