    protected void Foo(object o)
    {
        string strData = "Data" + o.ToString() ;
        validateStrData(strData);
        lblData.Text = strData;
    }
    private void validateStrData(string strData)
    {
        //some validating logic
    }
