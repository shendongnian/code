    private ObservableCollection<string> _fruits = new ObservableCollection<string>();
    public ObservableCollection<string> FruitInfo
    {
      get
      {
        using (var context = new Fruit())
        {
            this._fruits.Clear();
            foreach (var item in context.Fruits.OrderBy(s => s.FruitName))
            {
                this._fruits.Add(item.FruitName);
            }
            return this._fruits;
        }
      }
    }
