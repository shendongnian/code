    Thread t = new Thread(delegate() {
        DateTime lastCheck = DateTime.MinValue;
        while (IamRunning)
        {
            int dd = (DateTime.Now.Hour - lastCheck.Hour) * 3600 + (DateTime.Now.Minute - lastCheck.Minute) * 60 + DateTime.Now.Second - lastCheck.Second;
            if (dd >= checkDuration)
                if (!IsProcessOpen("ProcessName"))
                {
                    delApplication();  // You have a function to delete ...
                    break;
                }
        }
    });
    t.SetApartmentState(ApartmentState.STA);
    t.Start();
