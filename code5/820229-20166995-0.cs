    namespace DataBindingTest 
    {
    
        public partial class Form1 : Form
        
        {
    
            BindingSource bs;
            BindingList<Place> places = new BindingList<Place>();
            Place place1 = new Place("pl1", 2.2);
            Place place2 = new Place("pl2", 2.3);
    
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                bs = new BindingSource();
                places.Add(place1);
                places.Add(place2);
                bs.DataSource = places;
    
                listBox1.DataSource = bs;
                listBox1.DisplayMember = "Name";
                listBox1.DataBindings.Add(new Binding("Text", bs, "Name", true, DataSourceUpdateMode.OnPropertyChanged));
    
                Place place3 = new Place("pl3", 0);
                bs.Add(place3);
                places[2].Name = "Place3";
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                places[0].Name = "Place 1";
                places[1].Name = "Place 2";
            }
    
    
        }
    
    
        public class Place : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            string name;
            double losses;
    
            public Place(string n, double l)
            {
                name = n;
                losses = l;
            }
    
    
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    OnPropertyChanged("Name");
    
                }
            }
    
            public double Losses
            {
                get { return losses; }
                set { losses = value; }
            }
    
            protected void OnPropertyChanged(string PropertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    
    }
