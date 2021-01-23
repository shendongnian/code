            containerBuilder.Register((c, p) =>
            {
                if (!p.Named<bool>("CanResolveIMapWorld")) throw new Exception();
                return new MapWorld();
            });
            containerBuilder.Register( c =>
                new MapComposition
                {
                    MapWorld = c.Resolve<IMapWorld>(new NamedParameter("CanResolveIMapWorld", true))
                });
