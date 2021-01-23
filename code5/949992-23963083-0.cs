    Action task = () = {
        gvTaskCases.DataSource = null;
        
        if (gvTaskCases.Rows.Count != 0) // EXCEPTION IS THROWN HERE!
        {
            gvTaskCases.Rows.Clear(); // .Update();
        }
    };
    if(gvTaskCases.InvokeRequired) {
        gvTaskCases.Invoke(task);        
    }
    else {
        task();
    }
