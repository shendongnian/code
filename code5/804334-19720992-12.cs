    DataContainer _oldData = null;
    while(!UserClickedExit())
    {
        DataContainer newData = SafePointerContainer.Instance.Data;
        if (newData != _oldData)
        {
            RenderData(newData);
            _oldData = newData;
        }
        else
        {
            System.Threading.Thread.Sleep(1000);
        }
    {
