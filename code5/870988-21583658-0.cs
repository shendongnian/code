    if (context.tblVehicleMaint.Any(e => e.ActivityID == mo.AID && e.VID == mo.VID))
                    {
                        context.tblVehicleMaint.Attach(mo);
                        context.ObjectStateManager.ChangeObjectState(mo, System.Data.EntityState.Modified);
                    }
                    else
                    {
                        context.tblVehicleMaint.AddObject(mo);
                    }
    
                    context.SaveChanges();
