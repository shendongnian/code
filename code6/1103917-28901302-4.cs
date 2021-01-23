            var container = new Container(
                c => c.Scan(
                    s =>
                        {
                            s.TheCallingAssembly();
                            s.AddAllTypesOf(typeof(BaseService<>)).NameBy(t => t.Name);
                        }));
            var service = container.GetInstance<BaseService<SomeType>>("BaseServiceForSomeType");
