    public class FormAB : Form {
    
    	ComboBox combo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDown, Dock = DockStyle.Top };
    	Button btn = new Button { Text = "Button", Dock = DockStyle.Top };
    
    	public FormAB() {
    		Controls.Add(btn);
    		Controls.Add(combo);
    
    		DataTable table = new DataTable();
    		table.Columns.Add("FirstName");
    		table.Columns.Add("BirthDate", typeof(DateTime));
    
    		table.Rows.Add("Alan", DateTime.Today.AddYears(-20));
    		table.Rows.Add("Bob", DateTime.Today.AddYears(-35));
    
    		combo.DataSource = table;
    		combo.DisplayMember = "FirstName";
    		combo.ValueMember = "FirstName";
    
    		btn.Click += delegate {
    			Object rv = combo.Items.Cast<Object>().Where(r => combo.GetItemText(r) == "Bob").FirstOrDefault();
    			// either/or
    			//Object rv = combo.Items.Cast<DataRowView>().Where(r => (String) r[combo.DisplayMember] == "Bob").FirstOrDefault();
    			if (rv == null && combo.Items.Count > 0)
    				rv = combo.Items[0];
    			combo.SelectedItem = rv;
    		};
    	}
    }
