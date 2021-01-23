        IKernel _kernel;
        public DebugDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            if (model.Implementation != typeof(ComponentManager)) return false;
            if (dependency.TargetType != typeof (IEnumerable<IComponent>)) return false;
            return true;
        }
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            var handlers = _kernel.GetHandlers(typeof(IComponent));
            var components = new List<IComponent>();
            foreach (var handler in handlers)
            {
                if (handler.ComponentModel.Implementation == typeof(Component2)) continue;
                components.Add((IComponent)handler.Resolve(context));
            }
            return components;
        }
    }
