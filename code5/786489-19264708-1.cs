        TextBox txtBoxSolution = new TextBox();
        Label lblSolution = new Label();
        txtBoxSolution.ID = "txtBoxSolution" + controlNumber;
        txtBoxSolution.TextMode = TextBoxMode.MultiLine;
        txtBoxSolution.Width = 470;
        txtBoxSolution.Height = 50;
        lblSolution.ID = "lblSolution" + controlNumber;
        lblSolution.Text = "Step " + (controlNumber + 1) + ": ";
        lblSolution.Width = 200;
       
        plcSolution.Controls.Add(lblSolution);
       
        plcSolution.Controls.Add(txtBoxSolution);
      
          }
