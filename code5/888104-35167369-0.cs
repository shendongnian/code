    public static readonly DependencyProperty MyCollectionProperty = DependencyProperty.Register("MyCollection", typeof(ObservableCollection<T>), typeof(MainWindow));
    
            public ObservableCollection<T> MyCollection
            {
                get
                {
                    return this.GetValue(MyCollectionProperty) as string;
                }
                set
                {
                    this.SetValue(MyCollectionProperty, value);
                }
            }
    
    //assign the collection value at any time 
    MyCollection = ......
    
    //you can bind it as the past
