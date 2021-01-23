    private void TimerCallback_SendSbcData(object stateInfo)
    {
        try
        {
            SbcData data = new SbcData();
            this.network.Send(data);
        }
        catch (Exception ex)
        {
            MyLogToCardMethod(ex.ToString());
        }
    }
