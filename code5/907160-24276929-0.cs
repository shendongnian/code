    using EnvDTE;
    // Given CodeEnum someEnum already set...
    foreach (CodeVariable enumItem in someEnum.Members)
    {
        // Do something with value in InitExpression...
        object theValue = enumItem.InitExpression;
    }
