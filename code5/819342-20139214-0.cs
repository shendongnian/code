    public Action<string> UpdateFormAction {get; set;}   
 
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        string str = "";
        str+=e.UserState.ToString();
        label1.Text += str;
        UpdateForm2(label1.Text);
    }
    private void UpdateForm2(string text)
    {
       Action<string> handler = UpdateFormAction;
       if (handler != null)
           handler(text);
    }
