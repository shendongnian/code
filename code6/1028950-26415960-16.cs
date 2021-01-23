        /// <summary>
        /// reads & merges all the files for one specific date and create iga entry, merge their values, write them to the file
        /// </summary>
        /// <param name="date"></param>
        /// <param name="files"></param>
        /// <param name="streamWriter"></param>
        private static void ReadMergeAndWriteFilesForDay(
            DateTime date, List<string> files, StreamWriter streamWriter,
            IList<int> allResourcesInOrder  // Specifies the column order.
            )
        {
            var enteries = new Dictionary<IgaAdKey, IgaEntry>();
            foreach (string fileName in files)
                ReadFileForDay(fileName, enteries);
            var dateResources = new Dictionary<int, List<IgaAdKey>>();
            foreach (var key in enteries.Keys)
                dateResources.Add(key.ResourceId, key);
            // Sort the resources to output them in a consistent order.  Not required but good practice.
            dateResources.SortAll();
            for (int iRow = 0, nRows = dateResources.MaxCount(); iRow < nRows; iRow++)
            {
                for (int index = 0; index < allResourcesInOrder.Count; index++)
                {
                    if (index == 0)
                        streamWriter.Write(date.ToDateString() + ",");
                    else
                        streamWriter.Write(","); // Date goes under the resource ID for the first resource; otherwise leave it empty.
                    int resourceId = allResourcesInOrder[index];
                    IgaAdKey key;
                    IgaEntry value;
                    if (dateResources.TryGetValue(resourceId, iRow, out key)
                        && enteries.TryGetValue(key, out value))
                    {
                        streamWriter.Write(key.LocationId + ",");
                        streamWriter.Write(key.EditionId + ",");
                        streamWriter.Write(value.mClickCount + ",");
                        streamWriter.Write(value.mViewCount + ",");
                    }
                    else
                    {
                        streamWriter.Write(",");
                        streamWriter.Write(",");
                        streamWriter.Write(",");
                        streamWriter.Write(",");
                    }
                }
            }
        }
     Note `ReadFileForDay` was extracted from the first half of your `MergeFilesForDay`, [here](http://pastebin.com/ygKVKBjv).
