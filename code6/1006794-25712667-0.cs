    private void AutoCompleteSource()
    {
        textbox.BeginInvoke((Action) delegate {
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            auto.Add("text");
            textbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textbox.AutoCompleteCustomSource = auto;
        });
    }
