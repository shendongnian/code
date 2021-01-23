    internal const string PROXY_ATTRIBUTES_PROPERTY_KEY = "custom.proxy.attributes";
    protected override void CustomizeOptions(ProxyGenerationOptions options, IKernel kernel, ComponentModel model, object[] arguments)
    {
        if (model.ExtendedProperties.Contains(PROXY_ATTRIBUTES_PROPERTY_KEY))
        {
            var proxyAttributes = (IEnumerable<CustomAttributeBuilder>)model.ExtendedProperties[PROXY_ATTRIBUTES_PROPERTY_KEY];
            foreach (var attribute in proxyAttributes)
            {
                options.AdditionalAttributes.Add(attribute);
            }
        }
        base.CustomizeOptions(options, kernel, model, arguments);
    }
    configurer.ExtendedProperties(new Property(CustomProxyFactory.PROXY_ATTRIBUTES_PROPERTY_KEY, configurator.ProxySettings.CustomAttributes));
