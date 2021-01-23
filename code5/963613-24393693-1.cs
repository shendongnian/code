    private IEnumerable<String> GetChangedWithCrossReference()
    {
        return from originalRow in this.storeDataSet.PricesDataTable
                   join changedRow in this.storeDataSet.PricesDataTable.GetChanges(DataRowState.Changed)
                   on changedRow.Id == originalRow.Id
               select String.Format("Was {0}, became {1}",
                   originalRow ["Value"], 
                   changedRow["Value"]);
    }
