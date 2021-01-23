        TextBox txtBoxMoreSolution = new TextBox();
        Label lblMoreSolution = new Label();
        btn = new Button();
        btn.Text = "add step";
        btn.ID = "btn" + controlNumber;
        btn.Click += new EventHandler(btn_Click);
        ViewState["btnId"] = btn.ID;
        Label lbl = new Label();
        lbl.Text = "Soltuion" + (controlNumber + 1);
        lbl.ID = "moreSolution" + (controlNumber + 1);
        lbl.Font.Size = 20;
        lbl.Font.Underline = true;
        lbl.Font.Bold = true;
        txtBoxMoreSolution.ID = "txtBoxMoreSolution" + controlNumber;
        txtBoxMoreSolution.TextMode = TextBoxMode.MultiLine;
        txtBoxMoreSolution.Width = 470;
        txtBoxMoreSolution.Height = 50;
        lblMoreSolution.ID = "lblMoreSolution" + controlNumber;
        lblMoreSolution.Text = "Step " + n + ": ";
        lblMoreSolution.Width = 200;
       
        plcAddMoreSolution.Controls.Add(lbl);
       
        plcAddMoreSolution.Controls.Add(lblMoreSolution);
     
        plcAddMoreSolution.Controls.Add(txtBoxMoreSolution);
      
        plcAddMoreSolution.Controls.Add(btn);
       
       
    }
