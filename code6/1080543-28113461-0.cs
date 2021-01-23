    private string someproperty
    public string SomeProperty1 
    {
         get { return someproperty; };
         set
         {
             if (someproperty == value) return;
             someproperty = value;
             NotifyPropertyChanged("SomeProperty1");
             NotifyPropertyChanged("SomeProperty2");
         }
    }
    public string SomeProperty2 
    {
         get { return someproperty; };
         set
         {
             if (someproperty == value) return;
             someproperty = value;
             NotifyPropertyChanged("SomeProperty1");
             NotifyPropertyChanged("SomeProperty2");
         }
    }
    <TextBox Text="{Binding SomeProperty1, Mode=TwoWay}"></TextBox>
    <TextBox Text="{Binding SomeProperty2, Mode=TwoWay}"></TextBox>
