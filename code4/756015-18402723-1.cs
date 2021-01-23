    public void IntegrateRow(DataRow p_RowCible, DataRow p_RowSource)
    		{
    			try
    			{
    				foreach (DataColumn v_Column in p_RowCible.Table.Columns)
    				{
    					string ColumnName = v_Column.ColumnName;
    					if (p_RowSource.Table.Columns.Contains(ColumnName))
    					{
    						p_RowCible[ColumnName] = p_RowSource[ColumnName];
    					}
    				}
    			}
    			catch (Exception e)
    			{
    ...
