    namespace DataGridCheckBoxItemTest
    {
     public class DataGridTestVM : INotifyPropertyChanged
     {
       ObservableCollection<Source> source;
       Source s;
       int test;
    public DataGridTestVM()
    {
      source = new ObservableCollection<Source>();
      for (int i = 0; i < 10; i++)
      {
        s = new Source();
        s.test = i;
        source.Add(s);
      }
    }
    public ObservableCollection<Source> Source
    {
      get
      {
        return source;
      }
      set
      {
        source = value;
        OnPropertyChanged("Source");
      }
    }
    public int Test
    {
      get
      {
        return test;
      }
      set
      {
        test = value;
        OnPropertyChanged("Test");
      }
    }
    public Source Selected
    {
      get
      {
        return s;
      }
      set
      {
        s = value;
        Test = s.test;
        OnPropertyChanged("Selected");
      }
    }
       public event PropertyChangedEventHandler PropertyChanged;
       public void OnPropertyChanged(string name)
       {
         if (this.PropertyChanged != null)
         {
           this.PropertyChanged(this, new PropertyChangedEventArgs(name));
         }
       }
     }
     public class Source
     {
       public int test;
     }
    }
