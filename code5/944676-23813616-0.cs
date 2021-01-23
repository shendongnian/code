    private void ScriptToFileButton_Click(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            for (var i = 0; i < 50; i++)
            {
                Thread.Sleep(100);
                MyValue = i.ToString(CultureInfo.InvariantCulture);
            }
        })
        .ContinueWith(s =>
        {
            MyValue = "Scripting, please wait..";
            String text = DBObjectsTextArea.Text;
            String[] args = text.Split(' ');
            SQLScripter scripter = new SQLScripter();
            scripter.script(args);
            Thread.Sleep(3000); // This sleep is only used to simulate scripting
        })
        .ContinueWith(s =>
        {
            MyValue = "Done!";
        });
    }
