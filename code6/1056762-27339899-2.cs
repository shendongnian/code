    private void InitStates()
    {
        cbState.BeginUpdate();
        foreach(var state in StateArray.Names)
        {
            cbState.Items.Add(state);
        }
        cbState.EndUpdate();
    }
    
