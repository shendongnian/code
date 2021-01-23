    internal virtual RouteBase GetRoute(DbContextTypeProvider databaseContextTypeProvider, Type model)
    {
        Type catchallRoute = typeof(CatchallRoute<,>).MakeGenericType(new Type[] {
            databaseContextTypeProvider.DbContextType,
            model
        });
        Type routeTypeWrapper = typeof(RouteTypeWrapper<>).MakeGenericType(new Type[] {
            catchallRoute
        });
        RouteTypeProvider routeTypeProvider = (RouteTypeProvider)Activator.CreateInstance(routeTypeWrapper);
        return GetRoute(databaseContextTypeProvider, model, routeTypeProvider);
    }
