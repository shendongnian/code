    string sql = GetBulkCopySql(); // what should show up for the SqlBulkCopy event?
    using (MiniProfiler.Current.CustomTiming("SqlBulkCopy", sql)) 
    {
      RunSqlBulkCopy(); // run the actual SqlBulkCopy operation
    }
