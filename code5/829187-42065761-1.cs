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
					ds = (DataSet)bsFirst.DataSource;
				else
				{
					dt = (DataTable)bsFirst.DataSource;
					if (dt.DataSet == null) return dt;
					ds = dt.DataSet;
				}
				dt = ds.Relations[bs.DataMember].ChildTable;
			}
			return dt;
		}
