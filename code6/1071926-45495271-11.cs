    internal partial class Form2 : Form
    {
        private Form1 _parent;  // (need this variable)
        internal Form2(Form1 parent)  // (the default constructor)
        {
            InitializeComponent();
            _parent = parent;  // Save the argument.
            ...
            someUpDown.Maximum = Form1.foo;  // (Optionally read data from the parent form.)
            Form1.bar = someUpDown.Value;  // (Optionally write data to the parent form.)
            ...
            _parent.myProcedure(arg1);  // (Optionally call myProcedure() in the parent form.)
            ...
        }
        private void SomeButton_Click(object sender, EventArgs e)  // (callback from event loop)
        {
            ...
            someUpDown.Maximum = _parent.foo;  // (Optionally read data from the parent form.)
            _parent.bar = someUpDown.Value;  // (Optionally write data to the parent form.)
            ...
            _parent.myProcedure(arg1);  // (Optionally call myProcedure() in the parent form.)
            ...
        }
