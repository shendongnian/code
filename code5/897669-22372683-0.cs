	public class Class1
	{
		public Class1(Form1 form1)
		{
			_form1 = form1;
		}
		
		private Form1 _form1;
		
		public void Update()
		{
			for (int i = 0; i < 100; i++)
			{
				_form1.UpdateMyProgressBar(i); 
			}
		}
	}
