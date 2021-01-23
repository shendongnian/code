    public partial class MainWindow : Window
    {
        public class Mascot
        {
            string name;
            public string MyNameIs() // changed
            {
                return name;
            }
        }
        public class School
        {
            public Mascot myMascot;
        }
        public MainWindow()
        {
            InitializeComponent();
            School Houston = new School();
            Houston.myMascot = new Mascot();
            Houston.myMascot.MyNameIs();
        }
    }
