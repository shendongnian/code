    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
    
        private void ExecutedLoadXML(object sender, ExecutedRoutedEventArgs e)
        {
            string xml = @"<plan xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""schema.xsd"">
      <nagłówek>
        <autorzy>
          <nazwa>Autorzy:</nazwa>
          <autor atr=""one"">
            <numer>222</numer>
            <imię>Rust</imię>
            <nazwisko>Snow</nazwisko>
          </autor>
          <autor>
            <numer>111</numer>
            <imię>Ian</imię>
            <nazwisko>Nower</nazwisko>
          </autor>
        </autorzy>
      </nagłówek>
    </plan>
    ";
            var plan = XmlSerializationHelper.LoadFromXML<plan>(xml);
            var children = new List<plan>();
            children.Add(plan);
            treeView1.ItemsSource = null;
            treeView1.Items.Clear();
            treeView1.ItemsSource = children;
        }
        private void ExecutedSaveXML(object sender, ExecutedRoutedEventArgs e)
        {
            var planList = treeView1.ItemsSource as IList<plan>;
            if (planList != null && planList.Count > 0)
            {
                // Kludge to force pending edits to update
                treeView1.Focus();
                // Replace with actual save code!
                Debug.WriteLine(planList[0].GetXml());
            }
        }
    }
