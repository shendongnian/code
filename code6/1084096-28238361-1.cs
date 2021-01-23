    public event Action Completed
    {
        add  // gets called for each `obj.Completed += value;`
        {
            if (completed == null)
            {
                completed = new Action(value);
            }
            else
            {
                completed += value;
            }
        }
        remove  // gets called for each `obj.Completed -= value;`
        {
            if (completed != null)
            {
                completed -= value;
            }
        }
    }
    private Action completed;  // backing field (a delegate) for the event
