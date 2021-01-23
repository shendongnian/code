    private Dictionary<object, GridViewColumn> _columns = new Dictionary<object, GridViewColumn>();
    public MainWindow()
    {
        InitializeComponent();
        gv.Columns.CollectionChanged += Columns_CollectionChanged;
    }
    private void Columns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
       if((e.Action==NotifyCollectionChangedAction.Remove 
           || e.Action==NotifyCollectionChangedAction.Replace)
           && e.OldItems!=null)
       {
           foreach(GridViewColumn oldItem in e.OldItems)
           {
               if(_columns.ContainsKey(oldItem.Header)) _columns.Remove((oldItem.Header));
           }
       }
       if(e.NewItems!=null)
       {
           foreach(GridViewColumn newItem in e.NewItems)
           {
               _columns[newItem.Header] = newItem;
           }
       }
    }
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
       try
       {
            gv.Columns.CollectionChanged -= Columns_CollectionChanged;
        }
        catch { }
    }
    
    private GridViewColumn GetColumn(string header)
    {
        GridViewColumn column = null;
        _columns.TryGetValue(header, out column);
        return column;
    }
