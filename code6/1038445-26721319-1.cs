    namespace Scratch
    {
        class Program
        {
            static void Main(string[] args)
            {
                CParameter<int> ints = new CParameter<int>();
                CParameter<long> longs = new CParameter<long>();
                CInformation info = new CInformation();
                info.AddParameter(ints);
                info.AddParameter(longs);
                CParameter<int> ints2 = info.GetParameter<int>();
                // ints2 and ints will both refer to the same CParameter instance.
            }
        }
        public class CParameter<T>
        {
            public Type ParameterType { get { return typeof(T); } }
            public Dictionary<string, T> ValueByString;
        }
        public class CInformation
        {
            public string Version { get; set; }
            public string Name { get; set; }
            private List<object> parameters;
            public CInformation()
            {
                this.parameters = new List<object>();
            }
            public void AddParameter<T>(CParameter<T> parameter)
            {
                this.parameters.Add(parameter);
            }
            public CParameter<T> GetParameter<T>()
            {
                foreach (object parameter in this.parameters)
                {
                    if (parameter is CParameter<T>)
                        return (CParameter<T>)parameter;
                }
                throw new Exception("Parameter type " + typeof(T).FullName + " not found.");
            }
        }
    }
