            container.Kernel.GraphNodes
                .Cast<ComponentModel>()
                .ToList()
                .ForEach(component =>
                {
                    component.Services
                        .ToList()
                        .ForEach(type =>
                        {
                            var instance = container.Resolve(type);
                            Assert.IsNotNull(instance);
                        });
                });
