    bw.RunWorkerAsync(listbox.SelectedItem.ToString());
    ...
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        string selectedItem = (string)e.Argument;
        if(selectedItem == test)
        {
            testcase test1 = new testcase(); // instantiate the script
            test1.script1(); // run the code
        }
}
