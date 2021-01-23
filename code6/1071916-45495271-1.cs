    internal partial class Form2 : Form
    {
        private Form1 _parent;  // (need this variable)
        internal Form2(Form1 parent)  // (default constructor)
        {
            InitializeComponent();
            _parent = parent;  // Save the argument.
            ...
        }
        private void SomeButton_Click(object sender, EventArgs e)
        {
            ...
            _parent.myProcedure(optionalArg);  // Call Form1.myProcedure()
            ...
        }
