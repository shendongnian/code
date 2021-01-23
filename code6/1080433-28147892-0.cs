		private void dgvTidsregistrering_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			if (dgv.Columns[e.ColumnIndex].CellType == typeof(MaskedEditCell))
			{
				double minutes = 0;
				if (e.Value is double)
					minutes = Convert.ToInt32(e.Value);
				else
				{
					if (e.Value == DBNull.Value)
						minutes = 0;
					else
						double.TryParse((string)e.Value, out minutes);
				}
				Time t = Time.FromMinutes((int)minutes);
				e.Value = t.ToString();
			}
		}
