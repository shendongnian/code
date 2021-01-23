    private void showTotal(params string[] inputs)
    {
        int total = 0;
        foreach (string input in inputs)
        {
            int val;
            if (int.TryParse(input, out val))
                total += total;
        }
        result.Text = total.ToString();
    }
