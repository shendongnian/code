    public formResult(MyMainForm mainform)
    {
        this.InitializeComponent();
        this._mainForm = mainform;
        //Now you have access to public property ResultOut
        this.textBoxResult.Text = this._mainForm.ResultOut;
    }   
