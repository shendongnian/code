		public static DataTable Table(this BindingSource bs)
		{
			DataTable dt;
			if (bs.DataSource is DataTable)
				dt = (DataTable)bs.DataSource;
			else if (bs.DataSource is DataSet)
				dt = ((DataSet)bs.DataSource).Tables[bs.DataMember];
			else
			{
				var bsFirst = bs;
				while (bsFirst.DataSource is BindingSource)
					bsFirst = (BindingSource)bsFirst.DataSource;
				DataSet ds;
				if (bsFirst.DataSource is DataSet)
				{
					ds = (DataSet)bsFirst.DataSource;
					dt = ds.Tables[bsFirst.DataMember];
				}
				else
				{
					dt = (DataTable)bsFirst.DataSource;
					ds = dt.DataSet;
				}
				if (bsFirst != bs)
				{
					if (ds == null) return null;
					dt = ds.Relations[bs.DataMember].ChildTable;
				}
			}
			return dt;
		}
