    interface IDataProvider {
            List<int> Method1();
            List<string> Method2(string parameter1);
            List<string> Method2(string parameter1, string parameter2);
    }
    
    class DataProvider1 : IDataProvider {
        private readonly string[] Strings = { "A", "B", "C" };
        private bool _callFails;
        public DataProvider1(bool callFails) {
            _callFails = callFails;
        }
        public List<int> Method1() {
            if (_callFails) {
                throw new Exception();
            }
            return new List<int>(){1,2,3};
        }
        public List<string> Method2(string parameter1) {
            if (_callFails) {
                throw new Exception();
            }
            return Strings.Select(s => s + parameter1).ToList();
        }
        public List<string> Method2(string parameter1, string parameter2) {
            if (_callFails) {
                throw new Exception();
            }
            return Strings.Select(s => s + parameter1 + parameter2).ToList();
        }
    }
    
    class DataProvider2 : IDataProvider {
        private readonly string[] Strings = { "D", "E", "F" };
        public List<int> Method1() {
            return new List<int>(){4,5,6};
        }
        public List<string> Method2(string parameter1) {
            return Strings.Select(s => s + parameter1).ToList();
        }
        // overload
        public List<string> Method2(string parameter1, string parameter2) {
            return Strings.Select(s => s + parameter1 + parameter2).ToList();
        }
    }
   
    class Gateway : IDataProvider {
        private readonly List<IDataProvider> _dataProviders;
        public Gateway(IEnumerable<IDataProvider> dataProviders) {
            _dataProviders = new List<IDataProvider>(dataProviders);
        }
        public List<int> Method1() {
            return Execute<List<int>>();
        }
        public List<string> Method2(string parameter1) {
            return Execute<List<string>>(parameter1);
        }
        public List<string> Method2(string parameter1, string parameter2) {
            return Execute<List<string>>(parameter1, parameter2);
        }
        private T Execute<T>(params object[] parameters) {
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
            var methodInfo = typeof(IDataProvider).GetMethod(methodBase.Name, methodBase.GetParameters().Select(p => p.ParameterType).ToArray());
            var index = 0;
            while (index < _dataProviders.Count) {
                try {
                    return(T)methodInfo.Invoke(_dataProviders[index], parameters);
                } catch (Exception) {
                    index++;
                }
            }
            throw new Exception("None of the methods succeeded");
        }
    }
