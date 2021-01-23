    public partial class MainWindow : Window
    {
        public List<PortableObject> NCollection;
        public MainWindow()
        {
            InitializeComponent();
            NCollection = getdata();
            cboSelectSeries.DataContext = NCollection;
        }
        private List<PortableObject> getdata()
        {
            return new List<PortableObject>
                               {
                                   new PortableObject
                                       {
                                           SeriesNumber = 001,
                                           NId = 10,
                                       },
                                        new PortableObject
                                       {
                                           SeriesNumber = 002,
                                           NId = 20,
                                       },
                                        new PortableObject
                                       {
                                           SeriesNumber = 003,
                                           NId = 30,
                                       },
                               };
        }
    }
    public class PortableObject
    {
        public int SeriesNumber { get; set; }
        public int NId { get; set; }
    }
