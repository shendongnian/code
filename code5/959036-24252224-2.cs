    Public class Parameters
    {   private DataTable ParamList = new DataTable();
    
        public Parameters()
        {   //Default constructor, build datatable with two empty columns
            ParamList.TableName = "Parameter";
            ParamList.Columns.Add("Name",typeof(string));
            ParamList.Columns.Add("Value",typeof(object)); }
        ...
        public string ConvertToXML()
        {   string result;
    
            //Clone Datatable, change Object field to datatype String
            var dtClone = ParamList.Clone();
            dtClone.Columns["Value"].DataType = typeof(string);
            ParamList.AsEnumerable().CopyToDataTable(dtClone, LoadOption.OverwriteChanges);
            
            using(var sw = new System.IO.StringWriter())
            {   dtClone.WriteXml(sw);
                result = sw.ToString();
            }
            return result;
        }
    }
