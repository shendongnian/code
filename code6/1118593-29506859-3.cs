    Thread t = new Thread(delegate() {
        DateTime lastCheck = DateTime.MinValue;
        while (IamRunning)
        {
            var now = DateTime.Now;
            int dd = (now.Hour - lastCheck.Hour) * 3600 + (now.Minute - lastCheck.Minute) * 60 + now.Second - lastCheck.Second;
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
