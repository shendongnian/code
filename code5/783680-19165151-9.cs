    public ObservableCollection<YourEntity> Data
    {
         get { return (ObservableCollection<YourEntity>)GetValue(DataProperty); }
         set { SetValue(DataProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty DataProperty =
    DependencyProperty.Register("Data", typeof(ObservableCollection<YourEntity>), typeof(MainWindow), null);
    
    public void LoadDocs()
    {
         Context _Context = new Context();
         if(Data == null)
         {
             Data = new ObservableCollection<YourEntity>();
         }
         else
         {
             Data.Clear();
         }
         foreach(var doc in _Context.SP_GetDocuments(1).ToList())
         {
             Data.Add(doc);
         }
         _Context = null;
    }
