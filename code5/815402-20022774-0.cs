    [SetUp]
    public void SetUp()
    {
        m_myForm = new MyTestForm();
        m_myForm.Show(null);
    }
    [TearDown]
    public void TearDown()
    {
        m_myForm.Close();
        m_myForm.Dispose();
    }
    [Test]
    //... some tests using the member variable
