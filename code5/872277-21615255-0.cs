        private static DataTable LoadData(List<ZipCodeTerritory>zipCodeList, bool update = false)
        {
            DataTable dataTable = InitializeStructure();
            foreach (var zipcode in zipCodeList)
            {
                DataRow row = dataTable.NewRow();
                try
                {
                    row[0] = zipcode.ChannelCode.Trim();
                    row[1] = zipcode.DrmTerrDesc.Trim();
                    row[2] = zipcode.IndDistrnId.Trim();
                    row[3] = zipcode.StateCode.Trim();
                    row[4] = (string.IsNullOrWhiteSpace(zipcode.ZipCode) ? null : zipcode.ZipCode.Trim());
                    row[5] = zipcode.EndDate.Date;
                    row[6] = zipcode.EffectiveDate.Date;
                    row[7] = zipcode.LastUpdateId;
                    row[8] = DateTime.Now.Date;
                    row[10] = zipcode.ErrorCodes;
                    row[11] = zipcode.Status;
                    //Add the Id column if we're doing an update
                    if(update) row[9] = zipcode.Id;
                }
                catch (Exception ex)
                {
                    
                }
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
