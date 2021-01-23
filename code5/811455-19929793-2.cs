			var query = txtQuery.Text;
			var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
			try
			{
				string data;
				string schema;
				GetSchema(connectionString, query, out data, out schema);
				txtXML.Text = data;
				txtXSD.Text = schema;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
