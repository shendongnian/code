    public float RateLoadDifference
    {
        get
        {
            if (rbCurrentRateLoad != 0)
            {
                return rbRevisedRateLoad / rbCurrentRateLoad;
            }
            return 0;
        }
    }
