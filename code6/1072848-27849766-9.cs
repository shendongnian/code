	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SqlClient;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	namespace WindowsFormsApplication110
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
		}
		public partial class MyComponent : Component
		{
		}
		public partial class ggDataBase : Component
		{
			private string _ConnectionString = "";
			private SqlConnection connection = new SqlConnection();
			private SqlDataAdapter adapter = new SqlDataAdapter();
			private SqlCommand command = new SqlCommand();
			public string ConnectionString
			{
				get { return _ConnectionString; }
				set { _ConnectionString = value; }
			}
			public void FillDataTable(DataTable Table, string SqlText)
			{
				if ((connection.ConnectionString == null) || (connection.ConnectionString != _ConnectionString))
					connection.ConnectionString = _ConnectionString;
				if (connection.ConnectionString != null && connection.ConnectionString != "")
				{
					if (command.Connection == null)
						command.Connection = connection;
					command.CommandText = SqlText;
					command.CommandType = CommandType.Text;
					adapter.SelectCommand = command;
					adapter.Fill(Table);
				}
			}
		}
	}
