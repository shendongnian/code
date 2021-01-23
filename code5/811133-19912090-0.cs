    public async void MyButton_OnClick(object sender, EventArgs e)
    {
        try
        {
            Task t = ...your task...;
            var myResult = await t; // do whatever you like with your task's result (if any)
        }catch
        {
            // whatever you need
        }
    }
