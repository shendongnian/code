    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        ObservableCollection<DataClass> obj = new ObservableCollection<DataClass>();
        obj.Add(new DataClass("AA", "10", "10"));
        obj.Add(new DataClass("BB", "10", "10"));
        List2.ItemsSource = obj;
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        int sum = 0;
        for (int i = 0; i < List2.Items.Count; i++)
        {
            DataClass obj = (DataClass)List2.Items[i];
            sum += int.Parse(obj.FEstado.ToString());
        }
        MessageBox.Show(sum.ToString());
    }
    public class DataClass
    {
        public string FNome { get; set; }
        public string FEstado { get; set; }
        public string Quantity { get; set; }
        public DataClass() { }
        public DataClass(string FNome, string FEstado, string Quantity)
        {
            this.FNome = FNome;
            this.FEstado = FEstado;
            this.Quantity = Quantity;
        }
    }
