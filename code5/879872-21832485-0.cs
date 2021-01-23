    using (var PumaOEEModel = new OEEPumaDBEntities())
    {
        Parameter1 parameter = PumaOEEModel.Parameters.Single(p => p.Id == 1);
        parameter.ProductionWarning = int.Parse(txtProductionWarning.Text);
        parameter.ProductionDistress = int.Parse(txtProductionDistress.Text);
        parameter.ShiftStart = cmbShiftStart.Text;
        try
        {
            PumaOEEModel.SaveChanges();
        }
        catch
        {
            throw new Exception("Could not save changes.");  
        }
    }
