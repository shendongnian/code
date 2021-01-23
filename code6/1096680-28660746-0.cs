    <Grid>
        <StackPanel>
            <DataGrid x:Name="dgr" HorizontalAlignment="Left" ItemsSource="{Binding Path=Salaries, Mode=TwoWay}"
                      AutoGenerateColumns="True" VerticalAlignment="Top" Width="640" Height="192" >                
            </DataGrid>
            <TextBlock HorizontalAlignment="Left"  TextWrapping="Wrap"  VerticalAlignment="Top" Text="{Binding TotalSalary}">               
            </TextBlock>
        </StackPanel>
    </Grid>
     class ViewModel : INotifyPropertyChanged
    {
        private NotifiableCollection<Salary> salaries;        
        double _totalSal;
        public double TotalSalary
        {
            get { return _totalSal = Salaries.Sum(x => x.Amount); }
            set { _totalSal = value; }
        }
        public NotifiableCollection<Salary> Salaries
        {
            get { return salaries; }
            set
            {
                salaries = value;
                if (salaries != null)
                {
                    salaries.ItemChanged += salaries_ItemChanged;
                }
                
            }
        }
        void salaries_ItemChanged(object sender, NotifyCollectionChangeEventArgs e)
        {
            OnPropertyChanged("TotalSalary");
        }     
     
        public ViewModel()
        {
            Salaries = new NotifiableCollection<Salary>();
            for (int i = 0; i < 10; i++)
            {
                Salary s = new Salary() { Type="Type"+i,Amount=new Random().Next(20000,30000)};
                Salaries.Add(s);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
    class Salary : INotifyPropertyChanged
    {
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }
        private double amount;
        public double Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged("Amount"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
    public class NotifyCollectionChangeEventArgs : PropertyChangedEventArgs
        {
            public int Index { get; set; }
            public NotifyCollectionChangeEventArgs(int index, string propertyName) : base(propertyName) { Index = index; }
        }
    public class NotifiableCollection<T> : ObservableCollection<T> where T : class, INotifyPropertyChanged
    {
        public event EventHandler<NotifyCollectionChangeEventArgs> ItemChanged;
        protected override void ClearItems()
        {
            foreach (var item in this.Items)
                item.PropertyChanged -= ItemPropertyChanged;
            base.ClearItems();
        }
        protected override void SetItem(int index, T item)
        {
            this.Items[index].PropertyChanged -= ItemPropertyChanged;
            base.SetItem(index, item);
            this.Items[index].PropertyChanged += ItemPropertyChanged;
        }
        protected override void RemoveItem(int index)
        {
            this.Items[index].PropertyChanged -= ItemPropertyChanged;
            base.RemoveItem(index);
        }
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            item.PropertyChanged += ItemPropertyChanged;
        }
        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            T changedItem = sender as T;
            OnItemChanged(this.IndexOf(changedItem), e.PropertyName);
        }
        private void OnItemChanged(int index, string propertyName)
        {
            if (ItemChanged != null)
                this.ItemChanged(this, new NotifyCollectionChangeEventArgs(index, propertyName));
        }
    }
