        public void CompareLines(string[] fileNames)
        {
            var textFileDictionaries = new List<Dictionary<CCDDetail,List<int>>>();
            var reg  = new Regex(".{12}(.{17})(.{10})(.{8}).(.{6})(.{22})", RegexOptions.Compiled);
            var lineMatches = new List<LineMatch>();
            foreach(var f in fileNames)
            {
                var fileInnerText = File.ReadAllLines(f);
                var fileSpecText = new Dictionary<CCDDetail,List<int>>();
                for(int j = 1; j < fileInnerText.Length - 4; ++j) // ignore 1st and last 4 lines of file
                {
                    var mat = reg.Match(fileInnerText[j]);
                    for(int k=1; k<=5; ++k)
                    {
                        var key = new CCDDetail() { FieldId = k, Value = mat.Groups[k].Value };
                        //field and value may occur on multiple lines?
                        if (fileSpecText.ContainsKey(key) == false)
                            fileSpecText.Add(key, new List<int>());
                        fileSpecText[key].Add(j);
                    }
                }
                textFileDictionaries.Add(fileSpecText);
            }
            for(int i=0; i<textFileDictionaries.Count - 2; ++i)
            {
                for (int j = i+1; j < textFileDictionaries.Count - 1; ++j)
                {
                    foreach(var tup in textFileDictionaries[j])
                    {
                        if(textFileDictionaries[i].ContainsKey(tup.Key))
                        {
                            // the field value might occure on multiple lines
                            lineMatches.Add(new LineMatch() { 
                                File1Index=i,
                                File1Lines = textFileDictionaries[i][tup.Key],
                                File2Index=j,
                                File2Lines = textFileDictionaries[j][tup.Key]
                            });
                        }
                    }
                    /*
                    for (int k = 0; k < textFileDictionaries[j].Count; ++k)
                    {
                        var key = textFileDictionaries[j].Keys.ToArray()[k];
                        if (textFileDictionaries[i].ContainsKey(key))
                        {
                            // the field value might occure on multiple lines
                            lineMatches.Add(new LineMatch()
                            {
                                File1Index = i,
                                File1Lines = textFileDictionaries[i][key],
                                File2Index = j,
                                File2Lines = textFileDictionaries[j][key]
                            });
                        }
                    }
                   */
                }
            }
        }
    ....
    public class CCDDetail
    {
        public int FieldId { get; set; }
        public string Value { get; set; }
        public override bool Equals(object obj)
        {
            return FieldId == (obj as CCDDetail).FieldId && Value.Equals((obj as CCDDetail).Value);
        }
        public override int GetHashCode()
        {
            return FieldId.GetHashCode() + Value.GetHashCode();
        }
    }
    public class LineMatch
    {
        public int File1Index { get; set; }
        public List<int> File1Lines { get; set; }
        public int File2Index { get; set; }
        public List<int> File2Lines { get; set; }
    }
