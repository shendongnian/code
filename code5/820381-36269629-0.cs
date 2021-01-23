    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class Program
    	{
    		static void UseFormat(DataGridView dg)
    		{
    			dg.ColumnAdded += (sender, e) =>
    			{
    				if (e.Column.DataPropertyName == "GroupId")
    				{
    					e.Column.DefaultCellStyle.Format = "Group 0";
    				}
    			};
    		}
    
    		static void UseCellFormatting(DataGridView dg)
    		{
    			dg.CellFormatting += (sender, e) =>
    			{
    				if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
    				{
    					var column = dg.Columns[e.ColumnIndex];
    					if (column.DataPropertyName == "GroupId" && e.Value != null)
    					{
    						e.Value = "Group " + e.Value.ToString();
    						e.FormattingApplied = true;
    					}
    				}
    			};
    		}
    
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form, ReadOnly = true, AllowUserToAddRows = false };
    			UseFormat(dg);
    			//UseCellFormatting(dg);
    			var data = new DataTable();
    			data.Columns.Add("Id", typeof(int));
    			data.Columns.Add("GroupId", typeof(int));
    			var groupIds = Enumerable.Range(0, 15).ToArray();
    			for (int i = 0; i < 100000; i++)
    				data.Rows.Add(i, groupIds[i % groupIds.Length]);
    			dg.DataSource = data;
    			Application.Run(form);
    		}
    	}
    }
