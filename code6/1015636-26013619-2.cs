            var oldProvider = FilterProviders.Providers.Single(f => f is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(oldProvider);
            var container = new UnityContainer();
            var provider = new UnityFilterAttributeFilterProvider(container);
            FilterProviders.Providers.Add(provider);
            UnityConfig.RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
