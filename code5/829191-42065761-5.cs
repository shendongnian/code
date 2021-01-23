		public static DataTable Table(this DataGridView dgv)
		{
			DataTable dt;
			if (dgv.DataSource is BindingSource)
				dt = ((BindingSource)dgv.DataSource).Table();
			else if (dgv.DataSource is DataSet)
				dt = ((DataSet)dgv.DataSource).Tables[dgv.DataMember];
			else if (dgv.DataSource is DataTable)
				dt = (DataTable)dgv.DataSource;
			else
				dt = null;
			return dt;
		}
		public static DataTable Table(this BindingSource bs)
		{
			var bsFirst = bs;
			while (bsFirst.DataSource is BindingSource)
				bsFirst = (BindingSource)bsFirst.DataSource;
			DataTable dt;
			if (bsFirst.DataSource is DataSet)
				dt = ((DataSet)bsFirst.DataSource).Tables[bsFirst.DataMember];
			else if (bsFirst.DataSource is DataTable)
				dt = (DataTable)bsFirst.DataSource;
			else
				return null;
			if (bsFirst != bs)
			{
				if (dt.DataSet == null) return null;
				dt = dt.DataSet.Relations[bs.DataMember].ChildTable;
			}
			return dt;
		}
