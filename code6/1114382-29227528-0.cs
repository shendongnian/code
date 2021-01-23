		private string build_where(string where, string clause)
		{
			if (clause == "")
			{
				return where;
			}
			string sql;
			if (where == "")
			{
				sql = " where ";
				sql += clause;
			}
			else
			{
				sql = where;
				sql += "and ";
				sql += clause;
			}
			return sql;
		}
