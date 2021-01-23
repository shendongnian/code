    protected IBindingWhenInNamedWithOrOnSyntax<TImplementation> InternalToConstructor<TImplementation>(
        Expression<Func<IConstructorArgumentSyntax, TImplementation>> newExpression)
    {
        var ctorExpression = newExpression.Body as NewExpression;
        if (ctorExpression == null)
        {
            throw new ArgumentException("The expression must be a constructor call.", "newExpression");
        }
        this.BindingConfiguration.ProviderCallback = StandardProvider.GetCreationCallback(ctorExpression.Type, ctorExpression.Constructor);
        this.BindingConfiguration.Target = BindingTarget.Type;
        this.AddConstructorArguments(ctorExpression, newExpression.Parameters[0]);
        return new BindingConfigurationBuilder<TImplementation>(this.BindingConfiguration, this.ServiceNames, this.Kernel);
    }
