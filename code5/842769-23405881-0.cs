    public class ExcelReader
    {
        List<string> _sharedStrings;
        List<Dictionary<string, string>> _derivedData;
        public List<Dictionary<string, string>> DerivedData
        {
            get
            {
                return _derivedData;
            }
        }
        List<string> _header;
        public List<string> Headers { get { return _header; } }
        // e.g. cellID = H2 - only works with up to 26 cells
        private int GetColumnIndex(string cellID)
        {
            return cellID[0] - 'A';
        }
        public void StartReadFile(Stream input)
        {
            ZipArchive z = new ZipArchive(input, ZipArchiveMode.Read);
            var worksheet = z.GetEntry("xl/worksheets/sheet1.xml");
            var sharedString = z.GetEntry("xl/sharedStrings.xml");
            // get shared string
            _sharedStrings = new List<string>();
            // if there is no content the sharedStrings will be null
            if (sharedString != null)
            {
                using (var sr = sharedString.Open())
                {
                    XDocument xdoc = XDocument.Load(sr);
                    _sharedStrings =
                        (
                        from e in xdoc.Root.Elements()
                        select e.Elements().First().Value
                        ).ToList();
                }
            }
            // get header
            using (var sr = worksheet.Open())
            {
                XDocument xdoc = XDocument.Load(sr);
                // get element to first sheet data
                XNamespace xmlns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
                XElement sheetData = xdoc.Root.Element(xmlns + "sheetData");
                _header = new List<string>();
                _derivedData = new List<Dictionary<string, string>>();
                // worksheet empty?
                if (!sheetData.Elements().Any())
                    return;
                // build header first
                var firstRow = sheetData.Elements().First();
                // full of c
                foreach (var c in firstRow.Elements())
                {
                    // the c element, if have attribute t, will need to consult sharedStrings
                    string val = c.Elements().First().Value;
                    if (c.Attribute("t") != null)
                    {
                        _header.Add(_sharedStrings[Convert.ToInt32(val)]);
                    } else
                    {
                        _header.Add(val);
                    }
                }
                // build content now
                foreach (var row in sheetData.Elements())
                {
                    // skip row 1
                    if (row.Attribute("r").Value == "1")
                        continue;
                    Dictionary<string, string> rowData = new Dictionary<string, string>();
                    // the "c" elements each represent a column
                    foreach (var c in row.Elements())
                    {
                        var cellID = c.Attribute("r").Value; // e.g. H2
                        // each "c" element has a "v" element representing the value
                        string val = c.Elements().First().Value;
                        // a string? look up in shared string file
                        if (c.Attribute("t") != null)
                        {
                            rowData.Add(_header[GetColumnIndex(cellID)], _sharedStrings[Convert.ToInt32(val)]);
                        } else
                        {
                            // number
                            rowData.Add(_header[GetColumnIndex(cellID)], val);
                        }
                    }
                    _derivedData.Add(rowData);
                }
            }
        }
    }
