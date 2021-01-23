    class AutofacHttpControllerTypeResolver : IHttpControllerTypeResolver
            {
                private readonly IContainer _container;
    
                public AutofacHttpControllerTypeResolver(IContainer container)
                {
                    this._container = container;
                }
    
                public ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver)
                {
                    var q = from r in _container.ComponentRegistry.Registrations
                            let t = r.Activator.LimitType
                            where typeof(IHttpController).IsAssignableFrom(t) && t.Name.EndsWith("Controller")
                            select t;
                    return q.ToList();
                }
            }
		                                                         
