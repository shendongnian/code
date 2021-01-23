    public class TrayIconManager : ITrayIconManager
    {
        private readonly IDictionary<WeakReference, WeakReference> icons;
        public TrayIconManager()
        {
            icons = new Dictionary<WeakReference, WeakReference>();
        }
        public ITrayIcon GetOrCreateFor<T>()
        {
            if (!icons.Any(i => i.Key.IsAlive && typeof(T).IsAssignableFrom(i.Key.Target.GetType())))
                return Create<T>();
            var reference = icons.First(i => i.Key.IsAlive && typeof(T).IsAssignableFrom(i.Key.Target.GetType())).Value;
            if (!reference.IsAlive)
                return Create<T>();
            var wrapper = (TrayIconWrapper)reference.Target;
            if (wrapper.IsDisposed)
                return Create<T>();
            return wrapper;
        }
        private ITrayIcon Create<T>()
        {
            var rootModel = IoC.Get<T>();
            var view = ViewLocator.LocateForModel(rootModel, null, null);
            var icon = view is TaskbarIcon ? (TaskbarIcon)view : new TaskbarIcon();
            var wrapper = new TrayIconWrapper(icon);
            ViewModelBinder.Bind(rootModel, view, null);
            SetIconInstance(rootModel, wrapper);
            icons.Add(new WeakReference(rootModel), new WeakReference(wrapper));
            return wrapper;
        }
        private void SetIconInstance(object rootModel, ITrayIcon icon)
        {
            var instance = rootModel as ISetTrayIconInstance;
            if (instance != null)
                instance.Icon = icon;
        }
    }
