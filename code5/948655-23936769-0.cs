    private static Func<object, object> _cachedFunc;
    private static Delegate _cachedDel;
    static void Main(string[] args)
    {
        var model = new ModelA
        {
            PropB = new ModelB {PropC = new ModelC {PropD = new ModelD {PropE = new ModelE {PropF = "hey"}}}}
        };            
        const string property = "PropB.PropC.PropD.PropE.PropF";
        var watch = new Stopwatch();
        var t1 = MeasureTime(watch, () => ExtractValueDelegate(model, property), "compiled delegate dynamic invoke");
        var t2 = MeasureTime(watch, () => ExtractValueCachedDelegate(model, property), "compiled delegate dynamic invoke / cached");
        var t3 = MeasureTime(watch, () => ExtractValueFunc(model, property), "compiled func invoke");
        var t4 = MeasureTime(watch, () => ExtractValueCachedFunc(model, property), "compiled func invoke / cached");
        var t5 = MeasureTime(watch, () => ExtractValueStepByStep(model, property), "step-by-step reflection");
        var t6 = MeasureTime(watch, () => ExtractValueStandard(model), "standard access (model.prop.prop...)");
            
        Console.ReadLine();
    }
    public static long MeasureTime<T>(Stopwatch sw, Func<T> funcToMeasure, string funcName)
    {
        const int times = 100000;
        sw.Reset();
        sw.Start();
        for (var i = 0; i < times; i++)
            funcToMeasure();
        sw.Stop();
        Console.WriteLine(":: {0, -45}  - {1} iters tooks {2, 10} ticks", funcName, times, sw.ElapsedTicks);
        return sw.ElapsedTicks;
    }
    public static object ExtractValueDelegate(object source, string property)
    {        
        var ptr = GetCompiledDelegate(source.GetType(), property);
        return ptr.DynamicInvoke(source);            
    }
    public static object ExtractValueCachedDelegate(object source, string property)
    {        
        var ptr = _cachedDel ?? (_cachedDel = GetCompiledDelegate(source.GetType(), property));
        return ptr.DynamicInvoke(source);
    }
    public static object ExtractValueFunc(object source, string property)
    {        
        var ptr = GetCompiledFunc(source.GetType(), property);
        return ptr(source); //return ptr.Invoke(source);
    }        
    public static object ExtractValueCachedFunc(object source, string property)
    {        
        var ptr = _cachedFunc ?? (_cachedFunc = GetCompiledFunc(source.GetType(), property));
        return ptr(source); //return ptr.Invoke(source);
    }
    public static object ExtractValueStepByStep(object source, string property)
    {
        var props = property.Split('.');
        for (var i = 0; i < props.Length; i++)
        {
            var type = source.GetType();
            var prop = props[i];
            var pi = type.GetProperty(prop);
            if (pi == null)
                throw new ArgumentException(string.Format("Field {0} not found.", prop));
            source = pi.GetValue(source, null);
            if (source == null && i < props.Length - 1)
                throw new ArgumentNullException(pi.Name, "Extraction interrupted.");
        }
        return source;
    }
    public static object ExtractValueStandard(ModelA source)
    {
        return source.PropB.PropC.PropD.PropE.PropF;
    }
    private static Func<object, object> GetCompiledFunc(Type type, string property)
    {        
        var arg = Expression.Parameter(typeof(object), "x");
        Expression expr = Expression.Convert(arg, type);
        var propType = type;
        foreach (var prop in property.Split('.'))
        {
            var pi = propType.GetProperty(prop);
            if (pi == null) throw new ArgumentException(string.Format("Field {0} not found.", prop));
            expr = Expression.Property(expr, pi);
            propType = pi.PropertyType;
        }
        expr = Expression.Convert(expr, typeof(object));
        var lambda = Expression.Lambda<Func<object, object>>(expr, arg);
        return lambda.Compile();
    }
    private static Delegate GetCompiledDelegate(Type type, string property)
    {        
        var arg = Expression.Parameter(type, "x");
        Expression expr = arg;
        var propType = type;
        foreach (var prop in property.Split('.'))
        {
            var pi = propType.GetProperty(prop);
            if (pi == null) throw new ArgumentException(string.Format("Field {0} not found.", prop));
            expr = Expression.Property(expr, pi);
            propType = pi.PropertyType;
        }
        var delegateType = typeof(Func<,>).MakeGenericType(type, propType);
        var lambda = Expression.Lambda(delegateType, expr, arg);
        return lambda.Compile();
    }
