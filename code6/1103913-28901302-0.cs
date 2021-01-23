            var container = new Container(
                c => c.Scan(
                    s =>
                        {
                            s.TheCallingAssembly();
                            s.AddAllTypesOf(typeof(BaseService<>));
                        }));
