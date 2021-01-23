            using (var scope = container.BeginLifetimeScope()) {
                var someDynamicString = "Brand B";
                var personDude = scope.Resolve<PersonWithJacket>(new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(Jacket),
                    (pi, ctx) => ctx.Resolve<Jacket>(new NamedParameter("name", someDynamicString))));
            }
