        internal class ReadAllLinesFromFilesInDirectory
        {
            private List<string> AllPlainLinesFromAllFiles = new List<string>();
            private List<string> SortedJoinedTrimmedAllLines = new List<string>();
            public ReadAllLinesFromFilesInDirectory(string directoryPath, string TopicName, string LinesToExclude)
            {
                string[] fileEntries = Directory.GetFiles(directoryPath, TopicName + "*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".csv", StringComparison.InvariantCultureIgnoreCase)).ToArray();
                foreach (string fileEntry in fileEntries)
                {
                    List<string> ReadLinesFromFileToList = new List<string>(File.ReadAllLines(fileEntry, Encoding.Default)
                        .Where(x => !x.Contains(LinesToExclude))
                        .ToList());
                    for (int lineCount = 0; lineCount < ReadLinesFromFileToList.Count(); lineCount++)
                    {
                        ReadLinesFromFileToList[lineCount] = String.Format("{0};{1}", ReadLinesFromFileToList[lineCount], Path.GetFileNameWithoutExtension(fileEntry).Replace("-", string.Empty).ToUpper());
                    }
                    AllPlainLinesFromAllFiles.AddRange(ReadLinesFromFileToList);
                }
            }
            public List<string> SortedJoinedTrimmedAllLinesToList()
            {
                SortedJoinedTrimmedAllLines = AllPlainLinesFromAllFiles
                    .Select(x => new ProcessedLine(x))
                    .OrderBy(x => x.SortKey1)
                    .ThenBy(x => x.SortKey2)
                    .Select(x => x.JoinedTrimmed)
                    .ToList();
                return SortedJoinedTrimmedAllLines;
            }
            public List<string> ToList()
            {
                return AllPlainLinesFromAllFiles;
            }
        }
