	public partial class Form1 : Form
	{
		private SomeClass theObject = new SomeClass(); //keep a reference of the object.
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
           //here we do the binding... we want the 'Text' Property of the control to change if the 'SomeProperty' changes OnPropertyChanged
			textBox1.DataBindings.Add("Text",theObject,"SomeProperty",false,DataSourceUpdateMode.OnPropertyChanged);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			theObject.SomeProperty = "This works!"; //just a test button that changes the property...
		}
	}
