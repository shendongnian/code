	Below is my opinion	
    private void btn1_Click(object sender, EventArgs e)
			{
				try
				{
					if (Convert.ToInt32(txtreg.Text) >  0)
					{
						for (int i = 0; i < dgResult1.Columns.Count; i++)
						{
							if (dgResult1.Columns[i].HeaderText == "REGHRS")
							{
								for (int j = 0; j < dgResult1.Rows.Count; j++)
								{
									if          (Convert.ToInt32(dgResult1.Rows[j].Cells["REGHRS"].Value.ToString()) >= 12)
									{
										dgResult1.Rows[j].Cells["REGHRS"].Value = txtreg.Text;
										dgResult2.Rows[j].Cells["REGHRS"].Value = Convert.ToInt32(dgResult2.Rows[j].Cells["REGHRS"].Value.ToString().Trim()) - Convert.ToInt32(txtreg.Text);
										dgResult3.Rows[j].Cells["REGHRS"].Value = "0";//UpDate this
									}
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
				}
			}
