    #if DEBUG
            for (int i = 0; i < stend.PBBIBuckets.Count; i++)
            {
                //int serverIndex = 0;
    #else
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = m_maxThreads;
            Parallel.For(0, stend.PBBIBuckets.Count, options, (i) =>
            {
    #endif
                g1client.Message request;
                DataTable requestTable;
                request = new g1client.Message();
                requestTable = request.GetDataTable();
                requestTable.Columns.AddRange(
                    Locations.Columns.Cast<DataColumn>().Select(x => new DataColumn(x.ColumnName, x.DataType)).ToArray
                        ());
                FillPBBIRequestTables(requestTable, request, stend.PBBIBuckets[i], stend.BucketLen[i], stend.Hierarchies);
    #if DEBUG
            }
    #else
            });
    #endif
