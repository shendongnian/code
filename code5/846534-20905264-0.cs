    public partial class Form2 : Form
        private List<POI> pOIs_3D;
        public List<POI> POIs_3D
        {
            get { return pOIs_3D; }
            set { pOIs_3D = value; }
        }    
    
        public Form2()
        {
            InitializeComponent();
            POIs_3D = new List<POI>();
        }
