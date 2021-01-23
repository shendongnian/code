    public class MyDataSourceReturner
    {
        public static Object retDatasource(Object _dataContextOrders, int intCostCodeProfileId){
        var expCodes = (from cpdet in _dataContextOrders.CodeProfileDetails
                join cpd in _dataContextOrders.CodeProfileDefinitions on cpdet.CodeProfileDefinitionID equals cpd.ID
                join cp in _dataContextOrders.CodeProfiles on cpd.CodeProfileID equals cp.ID
                join cc in _dataContextOrders.FMSCostCentres on cpdet.CostCentreID equals cc.ID
                join ec in _dataContextOrders.FMSExpenseCodes on cpdet.ExpenseCodeID equals ec.ID
                where cp.ID == Convert.ToInt32(intCostCodeProfileId)
                                  && cpdet.CostCentreID == Convert.ToInt32(intCostCentreSelected)
                                  && ec.Active == true
                select new
                {
                    ec.ID,
                    ec.CostCentreID,
                    ExpenseCodeExternalRef = ec.ExternalRef,
                    ExpenseCodeDescription = ec.Description,
                    displayExpenseCode = ec.ExternalRef + " " + ec.Description
                 }).Distinct().OrderBy(ec => ec.displayExpenseCode);
        return expCodes;
        }
    }
