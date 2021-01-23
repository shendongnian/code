    private TheTypeOfTheObject xmlData;
    private void btnReadMethod_Click(object sender, System.EventArgs e)
    {
        xmlData = SomeFunctionToGetData();
    }
    private void cmbMethodNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        var someValue = xmlData.SomeValue;
    }
