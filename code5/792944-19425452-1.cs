        var overlaydb1 = new overlayData
        {
          DeviceId = "1111",
          TimestampUTC = new DateTime(2000, 2, 2, 10, 10, 10),
          OverlayData1 = "seconed seconed seconed "
        };
        try
        {
          db.overlayData.Attach(overlaydb1);
          db.ObjectStateManager.ChangeObjectState(overlaydb1, EntityState.Modified);
          db.SaveChanges();
        }
        catch (Exception ec) 
        {
          Console.WriteLine(ec.Message);
        }
