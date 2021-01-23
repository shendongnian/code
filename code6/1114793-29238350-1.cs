    public abstract class CmsAdminController : Controller
    {
        private Collection<Type> _allowedChildren = new Collection<Type>();
        // The type of child controllers allowed
        protected Collection<Type> AllowedChildren
        {
            get {return _allowedChildren; }
        }
        public void Registertype<T>() where T : IController
        {
            _allowedChildren.Add(typeof(T));
        }
    }
