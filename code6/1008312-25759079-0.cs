    IEnumerable<DataRow> TotalMisMatchedRecords = from Batchdata in ReportData_Batch.AsEnumerable()
                                                  join Trancm in ReportData_Transcom.AsEnumerable()
                                                  on Batchdata["LoadID"].ToString()
                                                  equals Trancm["lean_load_id"].ToString() into loads
                                                  from nullvalue in loads.DefaultIfEmpty()
                                                  where nullvalue == null
                                                  select Batchdata;
    foreach (DataRow batchRow in TotalMisMatchedRecords)
        MismatchedData.Rows.Add(
            batchRow["LoadID"].ToString(),
            batchRow["AltCarrierDesignation"].ToString(),
            batchRow["Carrier"].ToString(),
            batchRow["createDate"].ToString(),
            batchRow["vendorcode"].ToString()
            ); 
