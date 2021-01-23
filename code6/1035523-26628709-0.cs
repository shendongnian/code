    Dictionary<string, Func<string>> dic = new Dictionary<string, Func<string>>();
    private void test()
    {
        Button btn = new Button();
        btn.Text = "BlahBlah";
        dic.Add("Value", () => btn.Text);
    }
    private void test2()
    {
        Func<string> outval;
        dic.TryGetValue("Value", out outval);
        MessageBox.Show(outval());
    }
