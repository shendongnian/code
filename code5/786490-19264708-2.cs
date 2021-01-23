        Number = 0;
        lblSol.Text = "Solution 1";
        string str = (string)ViewState["btnId"];
        if (str != null)
        {
            btn = (Button)plcAddMoreSolution.FindControl(str);
            btn.Visible = false;
        }
        btnAdd.Visible = false;
        TotalNumberSolAdded++;
        AddMoreControls(TotalNumberSolAdded, 1);
    }
