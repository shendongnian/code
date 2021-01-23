    internal partial class Form2 : Form
    {
        private Form1 _parent;  // (need this variable)
        internal Form2(Form1 parent)  // (default constructor)
        {
            InitializeComponent();
            _parent = parent;  // Save the argument.
            ...
            aMaxUpDown.Maximum = Form1.foo;  // (Optionally read data from the parent form.)
            Form1.bar = aMaxUpDown.Value;  // (Optionally write data to the parent form.)
            ...
            _parent.myProcedure(optionalArg);  // Call Form1.myProcedure()
            ...
        }
        private void SomeButton_Click(object sender, EventArgs e)
        {
            ...
            aMaxUpDown.Maximum = _parent.foo;  // (Optionally read data from the parent form.)
            _parent.bar = aMaxUpDown.Value;  // (Optionally write data to the parent form.)
            ...
            _parent.myProcedure(optionalArg);  // Call Form1.myProcedure()
            ...
        }
