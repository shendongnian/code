    public class ProcessorClass
    {
        private SerializationBinder _binder;
        public ProcessorClass(SerializationBinder binder)
        {
            _binder = binder;
        }
        public string CallDoSomething(Stream s)
        {
            var formatter = new BinaryFormatter();
            formatter.Binder = _binder;
           var i = (IElement)formatter.Deserialize(s);
            return i.DoSomething("the processor");
        }
    }
