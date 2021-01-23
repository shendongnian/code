    public partial class Form1 : Form
    {
        private VehicleList vehicleList = new VehicleList
        {
            new Vehicle{ VehicleRegistration = "b"},
            new Vehicle{ VehicleRegistration = "a"}
        };
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = vehicleList;
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            vehicleList.SortBy(x => x.VehicleRegistration);
            UpdateListBox();
        }
        private void UpdateListBox()
        {
            listBox1.DataSource = null; //clear items
            listBox1.DataSource = vehicleList; //reset
        }
    }
    class VehicleList : List<Vehicle>
    {
        public void SortBy(Func<Vehicle, IComparable> theThingToCompare)
        {            
            this.Sort(delegate(Vehicle v1, Vehicle v2) 
            {
                return theThingToCompare(v1).CompareTo(theThingToCompare(v2)); 
            });
        }
    }
