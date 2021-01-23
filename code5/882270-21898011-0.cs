    private void NatureCheck
    {
        chkRec.CheckedChanged -= new System.EventHandler(chkRec_CheckedChanged);
        chkRec.Checked = !(lblRecID.Visible = txtRecID.Visible = Recip);
        chkRec.CheckedChanged += new System.EventHandler(chkRec_CheckedChanged);
    }
