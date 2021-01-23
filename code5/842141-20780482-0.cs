    protected override object SaveControlState()
    {
        var state = new List<string>(); // save the 2 properties
        state.Add(Text);
        state.Add(Text1);
        return state;
    }
    protected override void LoadControlState(object savedState)
    {
        var state = (List<string>)savedState;
        Text = state[0];
        Text1 = state[1];
    }
