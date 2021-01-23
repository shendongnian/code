    // <Name>Derived class name must ends with base class name</Name>
    warnif count > 0 
    from t in Application.Types
    where t.IsClass
    let baseClass = t.BaseClass
    where !baseClass.IsThirdParty // Skip all .NET Fx base classes, like System.Object
    where !t.SimpleName.EndsWith(baseClass.SimpleName)
    select new {t, baseClass }
