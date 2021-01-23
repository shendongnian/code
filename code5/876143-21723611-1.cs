// Results
                DataTable reportResult1 =  new DataTable(); // Your data table 1
                DataTable reportResult2 =  new DataTable(); // Your data table 2
                // Merge tables
                var commonColumns = reportResult1.Columns.OfType<DataColumn>().Intersect(reportResult2.Columns.OfType<DataColumn>(), new DataColumnComparer());
                // Remove DB Nulls, replace with empty strings
                reportResult1.RemoveColumnNulls(commonColumns.ToList());
                reportResult2.RemoveColumnNulls(commonColumns.ToList());
                
                reportResult1.PrimaryKey = commonColumns.ToArray();
                result.Merge(reportResult2, false, MissingSchemaAction.AddWithKey);
                result.Merge(reportResult1, false, MissingSchemaAction.AddWithKey);
                return result;
