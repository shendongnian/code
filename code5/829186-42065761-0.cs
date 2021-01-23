    public static DataTable Table(this BindingSource bs)
		{
			DataTable dt;
			var bsFirst = bs;
			while (true)
			{
				if (!(bsFirst.DataSource is BindingSource))
				{
					if (bs.DataSource is DataTable)
						dt = (DataTable)bs.DataSource;
					else if (bs.DataSource is DataSet)
						dt = ((DataSet)bs.DataSource).Tables[bs.DataMember];
					else
					{
						DataSet ds;
						if (bsFirst.DataSource is DataSet)
							ds = (DataSet)bsFirst.DataSource;
						else
							ds = ((DataTable)bsFirst.DataSource).DataSet;
						dt = ds.Relations[bs.DataMember].ChildTable;
					}
					break;
				}
				bsFirst = (BindingSource)bsFirst.DataSource;
			}
			return dt;
		}
