    public void TreeCompleted(bool completed)
    {
        this.SafeInvoke(() =>
        {
            if(completed) 
            {
                DiagnosisTree = treeBranchControl1.GetDiagnosisTree(null);
                pctLoader.Visible = false;
                btnSelectDiagnosis.Visible = false;
                lblDiagnosis.Visible = true;
                treeBranchControl1.Visible = true;
            }
            else 
            {
                DiagnosisId = 0;
                DiagnosisTree = null;
            }
        });   
    }
