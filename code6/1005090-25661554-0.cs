     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Disposed += (s, a) =>
                {
                    //Dispose unmanaged stuffs etc.
                };
        }
