            var container = new Container(
                c =>
                    {
                        c.For<IFoo>().Use<Foo>();
                        c.For<IGeoCoder>().Add<OviGeoCoder>().Named("default");
                        c.For<IGeoCoder>()
                            .Add<SqlCachingGeocoder>()
                            .Ctor<IGeoCoder>()
                            .Is(ctx => ctx.GetInstance<IGeoCoder>("default"))
                            .Named("SqlCaching");
                        c.For<IGeoCoder>()
                            .Use<RedisCachingGeocoder>()
                            .Ctor<IGeoCoder>()
                            .Is(ctx => ctx.GetInstance<IGeoCoder>("SqlCaching"));
                    });
