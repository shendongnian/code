    void Test()
    {
        TestHelper helper = new TestHelper();
        helper.x = 10;
        btn.Click += helper.Method;
    }
    private class TestHelper
    {
        public int x = 10;
        public void Method(object sender, EventArgs e)
        {
            MessageBox.Show(x.ToString());
        }
    }
