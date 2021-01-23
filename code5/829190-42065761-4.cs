		public static DataTable Table(this BindingSource bs)
		{
			var bsFirst = bs;
			while (bsFirst.DataSource is BindingSource)
				bsFirst = (BindingSource)bsFirst.DataSource;
			DataTable dt;
			if (bsFirst.DataSource is DataSet)
				dt = ((DataSet)bsFirst.DataSource).Tables[bsFirst.DataMember];
			else
				dt = (DataTable)bsFirst.DataSource;
			if (bsFirst != bs)
			{
				if (dt.DataSet == null) return null;
				dt = dt.DataSet.Relations[bs.DataMember].ChildTable;
			}
			return dt;
		}
