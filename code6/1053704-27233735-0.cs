    	public partial class test : UserControl
	{
		public string usrID 
		{ 
			get{return _usrId;} 
			set
			{
				_usrId = value;
				  UCtextBox.Text = value;
			}
		}
