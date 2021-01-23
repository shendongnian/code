    // Some test stuff, replace this with your own.
    Expression e = null;
    SqlProvider p = new SqlProvider();
    // Get the IProvider interface
    var iProvider = typeof(SqlProvider).FindInterfaces((t, o) => t.FullName == "System.Data.Linq.Provider.IProvider", null).FirstOrDefault();
    if (iProvider != null)
    {
        // Get the Compile method on the interface
        MethodInfo m = iProvider.GetMethod("Compile");
        // Call it!
        var output = m.Invoke(p, new object[] { e });
    }
