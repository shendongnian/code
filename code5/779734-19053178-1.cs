    class HeaderInfo
    {
        public HeaderInfo(string header)
        {
            throw new NotImplementedException("Parse out your header info here and populate the class")
        }
    
        public string Name {get; private set;}
        public string TypeInfo {get; private set;}
    }
    private List<HeaderInfo> ParseHeader(string header)
    {
        var headerInfo = new List<HeaderInfo>();
        string[] headerItems = //Split your header line in to indvidual items some how
        foreach(headerItem in headerItems)
        {
             headerInfo.Add(new HeaderInfo(headerItem));
        }
        return headerInfo;
    }
    private string TableString(List<HeaderInfo> headerInfo)
    {
         StringBuilder sb = new StringBuilder();
         foreach(var info in headerInfo)
         {
             sb.AppendFormat("{0} {1}, ", info.Name, info.TypeInfo);
         }
         sb.Remove(sb.Length -2, 2); //Remove the last ", "
         return sb.ToString();
    }
    private void YourMethod(string[] fnames)
    {
        ### fnames is an array of file paths (2 csv files)
        foreach string f in fnames)
        {
             ## snip
             List<HeaderInfo> headerInfo;
             using (StreamReader rdr = new StreamReader(f))
             {
                  string headerLine = read.line();  ## This is the array of table columns
                  headerInfo = ParseHeader(headerLine);
             }
             string tab = Path.GetFileNameWithoutExtension(f);
             string query = String.Format(@"create table [{0}] ({1})", tab, TableString(headerInfo));
        }
    }
