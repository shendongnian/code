    internal class Program
    {
        private static void Main(string[] args)
        {
            var cOldClass = new PlainOldClass();
            var classProxyWithTarget = 
                new ProxyGenerator().CreateClassProxyWithTarget(cOldClass,new Intercetor(cOldClass));
            classProxyWithTarget.PropertyOne = 42;
            classProxyWithTarget.PropertyTwo = "my string";
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class StaticDataAttribute : Attribute
    {
        public string StaticData { get; private set; }
        public StaticDataAttribute(string resourceKey)
        {
            StaticData = resourceKey;
        }
    }
    public interface IMyRuntimeData
    {
        string TabAccountLangs { get; }
        void OnPropertyChanged(string propertyName = null);
    }
    public class PlainOldClass : IMyRuntimeData
    {
        [StaticData("FirstProperty")]
        public virtual int PropertyOne { get; set; }
        public string PropertyTwo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string TabAccountLangs { get; private set; }
        public virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Intercetor: IInterceptor
    {
        private readonly IMyRuntimeData _runtimeData;
        public Intercetor(IMyRuntimeData runtimeData)
        {
            _runtimeData = runtimeData;
        }
        public void Intercept(IInvocation invocation)
        {
            var isPropertySetter = invocation.Method.Name.StartsWith("set_");
            var isPropertyGetter = invocation.Method.Name.StartsWith("get_");
            if (isPropertySetter)
            {
				//Pre Set Logic
                invocation.Proceed();
				//Post Set Logic
                var attribute = invocation.Method.GetCustomAttributes(false).Cast<StaticDataAttribute>().SingleOrDefault();
                if (attribute != null)
                {
                    string resourceKey = attribute.StaticData;
                    string tabAccountLangs = _runtimeData.TabAccountLangs;
					_runtimeData.OnPropertyChanged(invocation.Method.Name.Substring(4));
                }   
            } else if (isPropertyGetter)
            {
				//Pre Get Logic 
                invocation.Proceed();
				//Post Get Logic
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
	
