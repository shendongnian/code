    public void DoSomethingWithARideOnlyIfItsValid(Ride ride)
    {
        try
        {
            if (ride.IsValid() == false)
             {
                 throw new Exception("The ride is invalid");
             }
    
             //if it gets here, it means
             //that the function didn't throw an error
             rideManager.DoSomething(ride);
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
