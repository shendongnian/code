    public partial class changeValueForm : Form
    {
        private valueForm valueForm;
        
        public changeValueForm ClientCaller 
        { get { return valueForm}; 
          set { valueForm = value};
        }....
    
    public partial class valueForm : Form
    {
        ...
        private void Form1_Load(object sender, EventArgs e)
        {
            ....
            change = new changeValueForm();
            change.ClientCaller = this;
        }
