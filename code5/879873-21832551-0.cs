    OEEPumaDBEntities PumaOEEModel = new OEEPumaDBEntities();
    var parameter = PumaOEEModel.Parameters.Single(x => x.ID == myParameterId);
    parameter.ProductionWarning = int.Parse(txtProductionWarning.Text);
    parameter.ProductionDistress = int.Parse(txtProductionDistress.Text);
    parameter.ShiftStart = cmbShiftStart.Text;
    PumaOEEModel.SaveChanges();
