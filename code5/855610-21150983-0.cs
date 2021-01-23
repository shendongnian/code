    private TestInformation PopulateTestDataXml()
    {
        TestInformation UiTestData = new TestInformation();
        UiTestData.TestID = txtTestId.Text;
        UiTestData.TestUser = cmbUsers.SelectedItem.ToString();
        UiTestData.TestSampleType = txtSampleType.Text;
        UiTestData.TestSampleId = txtSampleId.Text;
        UiTestData.TestMethodNumber = Convert.ToInt32(cmbMethod.SelectedItem);
        UiTestData.TestTubeSn = txtTubeSerialNum.Text;
        UiTestData.TestComments = txtComments.Text;
        return UiTestData;
    }
