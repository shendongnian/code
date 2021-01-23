    public class GridModel
        {
            //public GridModel() { }
            public GridModel(List<object> GridDataSource, string GridName, int RecordCount,
                int PageRecordCount, int CurrentPageIndex, string Controller, string ActionName, string TargetID)
            {
                this.GridDataSource = GridDataSource;
                this.GridName = GridName;
                this.RecordCount = RecordCount;
                this.PageRecordCount = PageRecordCount;
                this.CurrentPageIndex = CurrentPageIndex;
                this.Controller = Controller;
                this.ActionName = ActionName;
                this.TargetID = TargetID;
    
    
            }
    
            public List<string> classNameList = new List<string>();
    
            public List<object> GridDataSource { get; set; }
            public string GridName { get; set; }
            public int RecordCount { get; set; }
            public int PageRecordCount { get; set; }
            public int CurrentPageIndex { get; set; }
            public string Controller { get; set; }
            public string ActionName { get; set; }
            public string TargetID { get; set; }
    
            private Dictionary<string, string> styles =
                new Dictionary<string, string>();
    
            private Dictionary<string, string> columns=
                new Dictionary<string, string>();        
    
            [ReadOnly(true)]
            public enum GridClasses
    	{
    	        GridTable,
                GridHeader,
                GridBody,
                GridFooter,
                GridAlternativeRow,
                GridPager
    	}
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="GridClass">Chose yor class from GridModel.GridClass Enum</param>
            /// <param name="CssStyle">Enter full css attribute and values in a string format. Something like this :
            /// "color:red; font-size:10px;"</param>
            public void SetGridStyle(GridModel.GridClasses GridClass, string CssStyle)
            {
                if (styles.ContainsKey(GridClass.ToString()))
                    styles[GridClass.ToString()] = CssStyle;
                else
                    styles.Add(GridClass.ToString(), CssStyle);
            }    
    
            /// <summary>
            /// 
            /// </summary>
            /// <returns>Return: The CSS style of getted class in CSS originall format.</returns>
            public string GetGridStyle(GridModel.GridClasses GridClass)
            {
                if (styles.ContainsKey(GridClass.ToString()))
                {
                    return " GridContainer" + GridName + " ." + GridClass.ToString() + "{" + styles[GridClass.ToString()] + "}";
                }
                else
                    return "";
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <returns>Return: The CSS style of all classes of grid in CSS originall format.</returns>
            public string GetGridStyle()
            {
                string css = "";
                foreach(KeyValuePair<string, string> d in styles)
                    if(d.Key == GridClasses.GridAlternativeRow.ToString())
                        css += " #GridContainer" + GridName + " ." + GridName + d.Key + " tr:nth-child(even){" + d.Value + "} ";
                    else if (d.Key == GridClasses.GridPager.ToString())
                    css += " #GridContainer" + GridName + " ." + GridName + d.Key + " span{" + d.Value + "} ";
                    else
                        css += " #GridContainer" + GridName + " ." + GridName + d.Key + "{" + d.Value + "} ";
                return css;
            }
    
            public void SetColumnsStyle(string ColumnName, string CssStyle)
            {
                if (columns.ContainsKey(ColumnName))
                    columns[ColumnName] = CssStyle;
                else
                    columns.Add(ColumnName, CssStyle);
            }
    
            public string GetColumnStyle()
            {
                string css = "";
                foreach (KeyValuePair<string, string> d in columns)
                    css += " #GridContainer" + GridName + " ." + GridName + d.Key + "{" + d.Value + "} ";
                return css;
            }
    
            public List<string> GetStyledColumns()
            {
                List<string> l = new List<string>();
                foreach (KeyValuePair<string, string> d in columns)
                    l.Add(d.Key);
                return l;
            }
    
            public string EditController = "";
            public string EditAction = "";
            public bool IsInEditMode = false;
            public string GridCssClass = "webgrid";
    
        }
