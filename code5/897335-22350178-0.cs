        if (targetType.IsInterface)
            {
                reference.Instance = this.generator.CreateInterfaceProxyWithoutTarget(targetType, additionalInterfaces, InterfaceProxyOptions, wrapper);
            }
            else
            {
                object[] parameters = context.Parameters.OfType<ConstructorArgument>()
                    .Select(parameter => parameter.GetValue(context, null))
                    .ToArray();
                reference.Instance = this.generator.CreateClassProxy(targetType, additionalInterfaces, ProxyOptions, parameters, wrapper);
            }
