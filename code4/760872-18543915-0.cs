        readonly string[] _types = 
            {
                "Bebidas não alcoólicas",
                "Bebidas Alcóolicas",
                "Fruta",
                "Hidratos de Carbono",
                "Peixe",
                "Carne",
                "Cereais",
                "Lacticínios",
                "Óleos/Gorduras",
                "Leguminosas",
                "Legumes"
            };
        public Form1()
        {
            InitializeComponent();
            SetTypes();
        }
        public void SetTypes()
        {
            comboBox1.DataSource = _types;
        }
