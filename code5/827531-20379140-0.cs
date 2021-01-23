     <ComboBox ItemsSource="{Binding Source={x:Static MemberType=local:MyWindow, Member=M_Category}}"/>
     public partial class MyWindow : MyBaseWindow
    {
        public static ObservableCollection<string> m_Category = new ObservableCollection<string>() { "Simulation", "Materials" };
        public static ObservableCollection<string> M_Category
        {
            get { return m_Category; }
        }
        ......
