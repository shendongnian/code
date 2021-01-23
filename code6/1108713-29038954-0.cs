    private void button3_Click(object sender, EventArgs e)
    {
        int i = -8;
        int j = MyGenericMethod<int>(i);
        string s = MyGenericMethod<string>("Testing");
    }
    private T MyGenericMethod<T>(T input)
    {
        // Do something to input
        return input;
    }
