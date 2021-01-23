    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            obj_arr[0] = new obj(4); // Problem Here
        }
        class obj
        {
            private int member;
            public obj(int n)
            { member = n; }
        }
        obj[] obj_arr = new obj[10];
    }
