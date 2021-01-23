    private string mCommunicationDetails;
    public string CommunicationDetails
    {
        get
        {
            return mCommunicationDetails;
        }
        set
        {
            bool changed = (mCommunicationDetails != value);
            mCommunicationDetails = value;
            if (changed)
            {
                CommunicationDetailsChanged.Raise(this, EventArgs.Empty);
            }
        }
    }
    public event EventHandler CommunicationDetailsChanged;
