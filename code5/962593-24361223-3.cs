     <DataGrid x:Name="dg" ItemsSource="{Binding Dic}" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="id" Binding="{Binding Key}"/>
                </DataGrid.Columns>
            </DataGrid>
    private Dictionary<int, List<string>> dic;
    
            public Dictionary<int, List<string>> Dic
            {
                get { return dic; }
                set { dic = value; }
            }
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                Dic = new Dictionary<int, List<string>>();
                Dic.Add(1, new List<string> { "a", "b", "c", "5" });
                Dic.Add(2, new List<string> { "d" });
                Dic.Add(3, new List<string> { "e", "f" });
    
                int count = 0;
                foreach (List<string> lst in Dic.Values)
                {
                    if (lst.Count > count)
                    {
    
                        for (int i = count; i < lst.Count; i++)
                        {
                            DataGridTextColumn column = new DataGridTextColumn();
                            column.Header = "name" + i;
                            column.Binding = new Binding(string.Format("Value[{0}]", i));
                            dg.Columns.Add(column);
                        }
                        count = lst.Count;
                    }
                }
    
    
            }
