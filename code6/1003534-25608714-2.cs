      Console.WriteLine("Writing to TA_{0}", fileType);
      using(var streamMaster = new StreamWriter(Settings.WorkingDirectory + "TA_" + fileType, true))
       {     
           streamMaster.Flush();
           int counter = 0;
           
           foreach (var tempFile in filesList)
           {
                ShowAnimation(++counter);
                var isZipped = tempFile.Contains(".gz");
                var dtTempFile = InternalUtils.GetTable(tempFile, isZipped);
                
                foreach (DataRow row in dtTempFile.Rows)
                {
                    if(dtTempFile.Rows.IndexOf(row) != 0) 
                        streamMaster.WriteLine(String.Join(",", row.ItemArray));
                }
                streamMaster.Write(dtTempFile.Copy());
                dtTempFile.Dispose();
            }
        }
        Console.WriteLine("TA_{0} Complete", fileType);
