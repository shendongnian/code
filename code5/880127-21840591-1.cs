    // Just paste the rest of this into a new console application to see it work!
    public class Program
    {
        private static readonly List<string> TOKENS = new List<string> {@"\v", @"\c", @"\o", @"\s"};
        private static readonly List<string> DISPLAY = new List<string> {"Vehicle", "Color", "Owner", "Speed"};
        private static readonly List<bool> ALLOW_MULTIPLE = new List<bool> {false, true, true, false};
        
        private class RecordEntry
        {
            public string Value { get; set; }
            public int Index { get; set; }
            public string DataType { get; set; }
            public override string ToString() { return DataType + ": " + Value; }
        }
        private class ParsedRecord
        {
            private List<RecordEntry> entries = new List<RecordEntry>();
            public List<RecordEntry> Entries { get { return entries; } }
        }
        public static void Main(string[] args)
        {
            // sample records (second has a \m which is ignored since it isn't a recognized token)
            var records = new[] {@"\vToyota\cBlue\c2Red\c3White\s200mph\oAndrew\o2John",
                                      @"\vChevy\c2Orange\cGreen\s50mph\o2Bob\mWhite"};
            var parsedData = new List<ParsedRecord>();
            foreach (var record in records)
            {
                // character by character parsing
                var currentParseRecord = new ParsedRecord();
                parsedData.Add(currentParseRecord);
                var currentRecord = new StringBuilder(record);
                var currentToken = new StringBuilder();
                for (var parseIdx = 0; parseIdx < currentRecord.Length; parseIdx++)
                {
                    currentToken.Append(currentRecord[parseIdx]);
                    var recordIdx = 0;
                    var index = TOKENS.IndexOf(currentToken.ToString());
                    if (index < 0) continue;
                    // current char is used up now (was part of the token)
                    parseIdx++;
                    if (ALLOW_MULTIPLE[index] && currentRecord.Length > parseIdx + 1)
                    {
                        // assuming less than 10 records max - if more, would need to pull multiple numeric values here
                        if (!Int32.TryParse(currentRecord[parseIdx] + "", out recordIdx)) recordIdx = 0;
                        else parseIdx++;
                    }
                    // find the next token or end of string
                    int valueLength = FindNextToken(currentRecord, parseIdx) - parseIdx;
                    if (valueLength <= 0) valueLength = currentRecord.Length - parseIdx;
                    currentParseRecord.Entries.Add(new RecordEntry
                        {
                            DataType = DISPLAY[index],
                            Index =  recordIdx,
                            Value = currentRecord.ToString(parseIdx, valueLength)
                        });
                    parseIdx += valueLength - 1;
                    currentToken.Clear();
                }
            }
        }
        private static int FindNextToken(StringBuilder value, int currentIndex)
        {
            for (var searchIdx = currentIndex; searchIdx < value.Length; searchIdx++) {
                if (TOKENS.Any(checkToken => value.Length > searchIdx + checkToken.Length &&
                                             value.ToString(searchIdx, checkToken.Length) == checkToken)) {
                    return searchIdx;
                }
            }
            return -1;
        }
    }
