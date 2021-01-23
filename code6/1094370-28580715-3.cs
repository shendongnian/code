    public void a0(object sender, System.EventArgs e)
        {
            var content = Convert.ToString(ba0.Content);
            if (string.IsNullOrEmpty(content) || string.IsNullOrWhiteSpace(content))
                ba0.Content = "X";
            else
                return;
        }
