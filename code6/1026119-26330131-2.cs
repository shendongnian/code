    public class Recepie : IDisposable
    {
        private readonly IList<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        public IList<Ingredient> Ingredients
        {
            get
            {
                return ingredients;
            }
        }
        protected virtual void OnIngredientsListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    var ing = item as Ingredient;
                    if (ing == null)
                    {
                        continue;
                    }
                    ing.Recepie = null;
                }
            }
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    var ing = item as Ingredient;
                    if (ing == null)
                    {
                        continue;
                    }
                    ing.Recepie = this;
                }
            }
        }
        public Recepie()
        {
            var obs = Ingredients as INotifyCollectionChanged;
            if (obs != null)
            {
                obs.CollectionChanged += OnIngredientsListChanged;
            }
        }
        public void Dispose()
        {
            int total = Ingredients.Count;
            for (int i = total; --i >= 0; )
            {
                Ingredients.RemoveAt(i);
            }
            var obs = Ingredients as INotifyCollectionChanged;
            if (obs != null)
            {
                obs.CollectionChanged -= OnIngredientsListChanged;
            }
        }
    }
    public class Ingredient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Recepie recepie;
        public virtual Recepie Recepie
        {
            get
            {
                return recepie;
            }
            set
            {
                if (object.Equals(recepie, value))
                {
                    return;
                }
                recepie = value;
                RaisePropertyChanged("Recepie");
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (string.Equals(title, value))
                {
                    return;
                }
                title = value;
                RaisePropertyChanged("Title");
            }
        }
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var local = PropertyChanged;
            if (local != null)
            {
                local.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
