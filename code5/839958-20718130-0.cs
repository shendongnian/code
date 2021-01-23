    			foreach (Control control in splitContainer1.Panel2.Controls)
			{
				if (control is GroupBox)
				{
					foreach (Control child in (control as GroupBox).Controls)
					{
						if (child is CheckBox)
						{
							((CheckBox)control).Checked = false;
						}
						else if (child is TextBox)
						{
							(control as TextBox).Clear();
						}
					}
				}
			}
