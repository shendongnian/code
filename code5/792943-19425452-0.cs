        var overlaydb1 = new overlayData
        {
          DeviceId = "1111",
          TimestampUTC = new DateTime(2000, 2, 2, 10, 10, 10),
          OverlayData1 = "seconed seconed seconed "
        };
    
        db.overlayData.Attach(overlaydb1);
        db.ObjectStateManager.ChangeObjectState(overlaydb1, EntityState.Modified);
        
        try
        {
          db.SaveChanges();
        }
        catch (Exception ec) 
        {
          Console.WriteLine(ec.Message);
        }
