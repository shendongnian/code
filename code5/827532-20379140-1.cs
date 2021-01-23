     <ComboBox ItemsSource="{Binding Source={x:Static Member=local:MyWindow.M_Category}}"/>
     public partial class MyWindow : MyBaseWindow
    {
        public static ObservableCollection<string> m_Category = new ObservableCollection<string>() { "Simulation", "Materials" };
        public static ObservableCollection<string> M_Category
        {
            get { return m_Category; }
        }
        ......
