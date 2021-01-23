	using System.ComponentModel;
	using System.Windows.Forms;
	namespace Test {
		public partial class MyDataGridView : DataGridView {
			bool _AllowUserToAddRows;
			[Category("Behavior")]
			[Description("Value indicating whether the option to add rows is displayed to the user")]
			[DefaultValue(false)]
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
			public new bool AllowUserToAddRows {
				get { return _AllowUserToAddRows; }
				set { base.AllowUserToAddRows = _AllowUserToAddRows = value; } }
		}
	}
