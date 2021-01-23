    private void allocationGridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e) 
            {
                try
                {
                    //int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);
                    string summaryTag = Convert.ToString((e.Item as GridSummaryItem).Tag);
                    GridView View = sender as GridView;
    
                    // Initialization 
                    if (e.SummaryProcess == CustomSummaryProcess.Start) {
                        
                        _sumOfValues = 0;
                        _sumOfTotalValue = 0;
                    }
    
                    //Calculate
                    if (e.SummaryProcess == CustomSummaryProcess.Calculate) {
                        
                        decimal colValueColumnValue = Convert.ToDecimal( View.GetRowCellValue(e.RowHandle, "Value") );
                        decimal colTotalValueColumnValue = Convert.ToDecimal( View.GetRowCellValue(e.RowHandle, "TotalValue") );
    
                        switch (summaryTag) {
                            case "percentageColumnCustomSummary":
                                _sumOfValues += colValueColumnValue;
                                _sumOfTotalValue += colTotalValueColumnValue;
                                break;
                        }
                    }
                    
                    // Finalization 
                    if (e.SummaryProcess == CustomSummaryProcess.Finalize) {
                        switch (summaryTag) {
                            case "percentageColumnCustomSummary":
                                e.TotalValue = 0;
                                if (_sumOfTotalValue != 0) {
                                    e.TotalValue = (_sumOfValues / _sumOfTotalValue);
                                }
                                
                                break;
                        }
                    }  
                }
                catch (System.Exception ex)
                {
                    _logger.ErrorException("allocationGridView_CustomSummaryCalculate", ex);
                }
                
            }
