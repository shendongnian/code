    /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            ObservableCollection<Tuple<string,string>>  _observableCollection = new ObservableCollection<Tuple<string, string>>();
            public MainWindow()
            {
                InitializeComponent();
            }
            private void MyMethod()
            {
                var tipList = registers.Select(x => x.Attribute("type").Value);
                var mapToList = registers.Select(x => x.Attribute("mapTo").Value);
                List<string> listresult =  new List<string>();
                List<string> listresultm = new List<string>();
                
    
                foreach (var reg in registers)
                {
                    foreach (var tpl in tipList)
                    {
                        var end = tpl.IndexOf(',');
                        var start = tpl.LastIndexOf('.', (end == -1 ? tpl.Length - 1 : end)) + 1;
                        var result = tpl.Substring(start, (end == -1 ? tpl.Length : end) - start);
                        listresult.Add(result);
                    }
    
                    foreach (var mpl in mapToList)
                    {
                        var endm = mpl.IndexOf(',');
                        var startm = mpl.LastIndexOf('.', (endm == -1 ? mpl.Length - 1 : endm)) + 1;
                        var resultm = mpl.Substring(startm, (endm == -1 ? mpl.Length : endm) - startm);
                        listresultm.Add(resultm);
                    }
                    int maxLenList = Math.Max(listresult.Count, listresultm.Count);
                    for (int i = 0; i <maxLenList; i++)
                    {
                        if (i < listresult.Count && i<listresultm.Count)
                        {
                            _observableCollection.Add(new Tuple<string, string>(listresult[i],listresultm[i]));
                        }
                        else if(i>=listresult.Count)
                        {
                            _observableCollection.Add(new Tuple<string, string>(string.Empty, listresultm[i]));
                        }
                         else if(i>=listresultm.Count)
                        {
                            _observableCollection.Add(new Tuple<string, string>( listresultm[i],string.Empty));
                        }
                    }
                }
                dataGrid1.ItemsSource= _observableCollection;  
            }
