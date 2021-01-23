    var query = new TableQuery<AnalyticsTableModel>().Where(
                    TableQuery.GenerateFilterConditionForDate(
                        "ResponseTime", 
                         QueryComparisons.GreaterThan,  
                         fromDate));
