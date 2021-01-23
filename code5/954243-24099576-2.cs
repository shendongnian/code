    public class ExtractCsvIntoSql
    {
        private string CsvPath, Separator;
        private bool HasHeader;
        private List<string[]> Lines;
        private List<string> Query;
        /// <summary>
        /// Header content of the CSV File
        /// </summary>
        public string[] Header { get; private set; }
        /// <summary>
        /// Template to be used in each INSERT Query statement
        /// </summary>
        public string LineTemplate { get; set; }
        public ExtractCsvIntoSql(string csvPath, string separator, bool hasHeader = false)
        {
            this.CsvPath = csvPath;
            this.Separator = separator;
            this.HasHeader = hasHeader;
            this.Lines = new List<string[]>();
            // you can also set this
            this.LineTemplate = "INSERT INTO [table1] SELECT ({0});";
        }
        /// <summary>
        /// Generates the SQL Query
        /// </summary>
        /// <returns></returns>
        public List<string> Generate()
        {
            if(this.CsvPath == null)
                throw new ArgumentException("CSV Path can't be empty");
            // extract csv into object
            Extract();
            // generate sql query 
            GenerateQuery();
            return this.Query;
        }
        private void Extract()
        {
            string line;
            string[] splittedLine;
            int iLine = 0;
            try
            {
                using (StreamReader sr = File.OpenText(this.CsvPath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        splittedLine = line.Split(new string[] { this.Separator }, StringSplitOptions.None);
                        if (iLine == 0 && this.HasHeader)
                            // header line
                            this.Header = splittedLine;
                        else
                            this.Lines.Add(splittedLine);
                        iLine++;
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null)
                    while (ex.InnerException != null)
                        ex = ex.InnerException;
                throw ex;
            }
            // Lines will have all rows and each row, the column entry
        }
        private void GenerateQuery()
        {
            foreach (var line in this.Lines)
            {
                string entries = string.Concat("'", string.Join("','", line))
                                       .TrimEnd('\'').TrimEnd(','); // remove last ",'" 
                this.Query.Add(string.Format(this.LineTemplate, entries));
            }
        }
    }
