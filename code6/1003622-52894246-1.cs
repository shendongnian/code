    while (true)
    {
        // Perform the periodic background work
        // This can update data structures used by the UI when it paints
        CallMyRoutineToRefreshDataForUI();
        // Optionally report to UI. 
        isDbAvail.ReportProgress(0, connection.isDbAvail);
        // Use Sleep to give up control, rather than using a Timer to regain control
        System.Threading.Thread.Sleep(8000);
    }
