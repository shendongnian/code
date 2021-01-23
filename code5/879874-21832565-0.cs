        OEEPumaDBEntities PumaOEEModel = new OEEPumaDBEntities();
        // id here is the id of the record you want to update
        Parameter1 parameter = PumaOEEModel.Parameter1.Singl(p=>p.ID == id);
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
