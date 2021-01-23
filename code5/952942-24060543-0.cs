    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        string selectedItem = "";
        this.Dispatcher.Invoke(new Action(() => 
        {
            selectedItem = listbox.SelectedItem.ToString();
        }
        if(selectedItem == test)
        {
            testcase test1 = new testcase(); // instantiate the script
            test1.script1(); // run the code
        }
    }
