        get { return (int)(ViewState["TotalNumberSolStepAdded"] ?? 0); }
        set { ViewState["TotalNumberSolStepAdded"] = value; }
    }
    protected int Number
    {
        get { return (int)(ViewState["Number"] ?? 0); }
        set { ViewState["Number"] = value; }
    }
    private void AddMoreStepControls(int controlNumber, int counter)
    {
        TextBox txtBoxMoreStepSolution = new TextBox();
        Label lblMoreStepSolution = new Label();
        txtBoxMoreStepSolution.ID = "txtBoxMoreStepSolution" + controlNumber;
        txtBoxMoreStepSolution.TextMode = TextBoxMode.MultiLine;
        txtBoxMoreStepSolution.Width = 470;
        txtBoxMoreStepSolution.Height = 50;
        lblMoreStepSolution.ID = "lblMoreStepSolution" + controlNumber;
        lblMoreStepSolution.Text = "Step " + (counter + 1) + ": ";
        lblMoreStepSolution.Width = 200;
      
        plcAddMoreSolution.Controls.Add(lblMoreStepSolution);
       
        plcAddMoreSolution.Controls.Add(txtBoxMoreStepSolution);
     
       
    }
