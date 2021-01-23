    /// <summary>
    		/// Returns the index of a column with the specified DataField string (or SortExpression if TemplateField). Throws an exception if not found.
    		/// </summary>
    		/// <param name="gv"></param>
    		/// <param name="DataField"></param>
    		/// <returns></returns>
    		public static int GetColumnIndex(this System.Web.UI.WebControls.GridView gv, string DataField)
    			{
    			foreach (System.Web.UI.WebControls.DataControlField column in gv.Columns)
    				{
    				if (column.GetType() == typeof(System.Web.UI.WebControls.BoundField))
    					{
    					System.Web.UI.WebControls.BoundField bf = (System.Web.UI.WebControls.BoundField)column;
    					if (bf.DataField == DataField)
    						{
    						return gv.Columns.IndexOf(bf);
    						}
    					}
    				else if (column.GetType() == typeof(System.Web.UI.WebControls.HyperLinkField))
    					{
    					System.Web.UI.WebControls.HyperLinkField hlf = (System.Web.UI.WebControls.HyperLinkField)column;
    					if (hlf.SortExpression == DataField)
    						{
    						return gv.Columns.IndexOf(hlf);
    						}
    					}
    				else if (column.GetType() == typeof(System.Web.UI.WebControls.TemplateField))
    					{
    					System.Web.UI.WebControls.TemplateField tf = (System.Web.UI.WebControls.TemplateField)column;
    					if (tf.SortExpression == DataField)
    						{
    						return gv.Columns.IndexOf(tf);
    						}
    					}
    
    				}
    			throw new ApplicationException("Column " + DataField + " not found in GridView " + gv.ID);
    			}
