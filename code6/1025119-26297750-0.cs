	public partial class Form1 : Form 
	{
		public Form1()
		{
			InitializeComponent();
			
			var myClass = new MyClass(this.richtextbox1);
			myClass.SetTextBoxText("hello");
		}   
	}
	class MyClass
	{
		RichTextBox _textBox;
		public MyClass(RichTextBox textBox)
		{
			_textBox = textBox;
		}
	
		public void SetTextBoxText(string text) 
		{
			_textBox.Clear();
			_textBox.Text = text;
		}
	}
