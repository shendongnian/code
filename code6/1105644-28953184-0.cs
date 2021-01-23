            var assembly = Assembly.GetAssembly(typeof(Program));
            var types = assembly
                .GetTypes()
                .Where(x => x.IsClass && x.GetInterfaces().Any());
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces().Where(x => x.Assembly == assembly);
                foreach (var iface in interfaces)
                {
                    var classMethods = type.GetMethods();
                    foreach (var interfaceMethod in iface.GetMethods())
                    {
                        var classMethod = classMethods.First(x => x.ToString() == interfaceMethod.ToString());
                        Debug.Assert(
                            interfaceMethod.GetParameters().Select(x => x.Name).SequenceEqual(classMethod.GetParameters().Select(x => x.Name)),
                            "Incorrect parameter names in method: " + type.Name + "." + classMethod.Name);
                    }
                }
            }
