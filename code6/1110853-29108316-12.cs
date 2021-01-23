    public class ModelToViewModelTranslator : ITranslator
    {
        public Type SourceType
        {
            get { return typeof(Model); }
        }
        public Type DestinationType
        {
            get { return typeof(ViewModel); }
        }
        public TDest Translate<TSource, TDest>(TSource toTranslate)
        {
            Model source = toTranslate as Model;
            ViewModel destination = null;
            if (source != null)
            {
                destination = new ViewModel()
                {
                    Property1 = source.Property1,
                    Property2 = source.Property2.ToString()
                };
            }
            return (TDest)(object)destination;
        }
    }
    public class ViewModelToModelTranslator : ITranslator
    {
        public Type SourceType
        {
            get { return typeof(ViewModel); }
        }
        public Type DestinationType
        {
            get { return typeof(Model); }
        }
        public TDest Translate<TSource, TDest>(TSource toTranslate)
        {
            ViewModel source = toTranslate as ViewModel;
            Model destination = null;
            if (source != null)
            {
                destination = new Model()
                {
                    Property1 = source.Property1,
                    Property2 = int.Parse(source.Property2)
                };
            }
            return (TDest)(object)destination;
        }
    }
