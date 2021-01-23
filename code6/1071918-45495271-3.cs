    internal partial class Form2 : Form
    {
        private Form1 _parent;  // (need this variable)
        internal Form2(Form1 parent)  // (default constructor)
        {
            InitializeComponent();
            _parent = parent;  // Save the argument.
            someMaxUpDown.Maximum = Form1.foo;  // (Optionally read data from the parent form.)
            ...
        }
        private void SomeButton_Click(object sender, EventArgs e)
        {
            ...
            _parent.myProcedure(optionalArg);  // Call Form1.myProcedure()
            ...
            Form1.foo = someMaxUpDown.Value;  // (Optionally write data to the parent form.)
            ...
        }
