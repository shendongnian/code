    public class TypeConvertor {
        private readonly Dictionary<Type, IConvertor> _convertors =
            new Dictionary<Type, IConvertor>();
        public void Register<TIn, TOut>(Func<TIn, TOut> conversion) {
            _convertors.Add(typeof(TIn), new Convertor<TIn, TOut>(conversion));
        }
        public object Convert(object obj) {
            if (obj == null)
                throw new ArgumentNullException("obj");
            return _convertors[obj.GetType()].Convert(obj);
        }
    }
