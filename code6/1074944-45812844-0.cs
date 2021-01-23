                CloudTableClient tableClient = _storageAccount.CreateCloudTableClient();
                CloudTable metricsCapacityTable = tableClient.GetTableReference(Constants.AnalyticsConstants.MetricsCapacityBlob);
                List<string> selectedColumns = new List<string>();
                selectedColumns.Add("Capacity");
                string yesterday = DateTime.UtcNow.Date.AddDays(-1).ToString("yyyyMMddT0000");
                
                dataResult = await metricsCapacityTable.ExecuteAsync(TableOperation.Retrieve(yesterday, "data", selectedColumns));
                
                DynamicTableEntity ddte = (DynamicTableEntity)dataResult.Result;
                double? dataValueInBytes = ddte.Properties["Capacity"].Int64Value;
