		protected void chkTelephone_CheckedChanged(object sender, EventArgs e)
			{
				for (int i = 0; i < GridView1.Rows.Count; i++)
				{
					int CCnt = GridView1.HeaderRow.Cells.Count - 1;
					CheckBox chkSwitch = GridView1.HeaderRow.Cells[CCnt].FindControl("chkToggle") as CheckBox; //true / false -- this has to be the number of columns.
					Label lblTelephone = GridView1.Rows[i].FindControl("lblTelephone") as Label; //8885551234 
					Label lblHiddenTel = GridView1.Rows[i].FindControl("lblHiddenTel") as Label; //8885551234 
					
					string formatShort = chkSho.ToString() + "-" + lblHiddenTel.Text.Substring(lblHiddenTel.Text.Length - Math.Min(4, lblHiddenTel.Text.Length));
					string formatFone = "(" + lblHiddenTel.Text.Substring(lblHiddenTel.Text.Length - 10, 3) + ") "
							+ lblHiddenTel.Text.Substring(lblHiddenTel.Text.Length - 7, 3) + "-"
							+ lblHiddenTel.Text.Substring(lblHiddenTel.Text.Length - Math.Min(4, lblHiddenTel.Text.Length));
					if (chkSwitch.Checked)
					{
						lblTel.Text = formatShort;
					}
					else
					{
						lblTel.Text = formatFone;
					}
				}
			}					
