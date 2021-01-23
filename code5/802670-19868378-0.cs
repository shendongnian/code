    public class MyClass
    {
        private TabAccountLangs TabAccountLangs = //whatever;
        private readonly Wrapper _wrapper = new Wrapper(TabAccountLangs);
        private string Decsription
        {
            get { return _wrapper.GetValue<string>("TextAccount"); }
            set { _wrapper.SetValue<string>("TextAccount", value, OnPropertyChanged); }
        }
    }
    public class Wrapper
    {
        private Dictionary<string, object> _map = new Dictionary<string, object>(); 
        //pass TabAccountLangs to constructor and assign to _langs property
        //Constructor should be here
        public T GetValue<T>(string name)
        {
            object result;
            if (!_map.TryGetValue(name, out result))
            {
                result = GetLang(_langs, name);
                _map[name] = result;
            }
            return (T) result;
        }
        public void SetValue<T>(string name, T value, Action onSuccess)
        {
            object previousValue;
            if (_map.TryGetValue(name, out previousValue) && previousValue.Equals(value))
            {
                return;
            }
            SetLang(_langs, name);
            _map[name] = value;
            onSuccess();
        }
        //The rest
    }
