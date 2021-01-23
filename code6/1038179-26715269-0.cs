    catch (ConstraintException)
    {
        DataRow[] rowErrors = this.YourDataSet.YourDataTable.GetErrors();
    
        System.Diagnostics.Debug.WriteLine("YourDataTable Errors:" 
            + rowErrors.Length);
    
        for (int i = 0; i < rowErrors.Length; i++)
        {
            System.Diagnostics.Debug.WriteLine(rowErrors[i].RowError);
    
            foreach (DataColumn col in rowErrors[i].GetColumnsInError())
            {
                System.Diagnostics.Debug.WriteLine(col.ColumnName 
                    + ":" + rowErrors[i].GetColumnError(col));
            }
        }
    }
