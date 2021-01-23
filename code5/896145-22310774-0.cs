    private void doneButton_Click(object sender, EventArgs e) {
        // call your new method here:
        NameYourMethodSomething();
        Environment.Exit(0);
    }
    private void otherButton_Click(object sender, EventArgs e) {
        // call your method again:
        NameYourMethodSomething();
        Do_Something_Else_Whatever_You_Want_Here();
    }
    // put your stuffs here:
    private void NameYourMethodSomething() {
        // actual end result osnap and right click values
        int findOvalue = 0;
        int findMvalue = 0;
        // OSNAP values
        int endpoint = 1;
        int midpoint = 2;
        int center = 4;
        int node = 8;
        int quadrant = 16;
        int intersection = 32;
        int insertion = 64;
        int perpendicular = 128;
        int tangent = 256;
        int nearest = 512;
        int apparentIntersection = 2048;
        int extension = 4096;
        int parallel = 8192;
        //int none = 0;
        //int clearAll = 1024;
        // find the OSNAP value
        if (cbxEndpoint.Checked) { findOvalue += endpoint; }
        if (cbxMidpoint.Checked) { findOvalue += midpoint; }
        if (cbxCenter.Checked) { findOvalue += center; }
        if (cbxNode.Checked) { findOvalue += node; }
        if (cbxQuadrant.Checked) { findOvalue += quadrant; }
        if (cbxIntersection.Checked) { findOvalue += intersection; }
        if (cbxInsertion.Checked) { findOvalue += insertion; }
        if (cbxPerpendicular.Checked) { findOvalue += perpendicular; }
        if (cbxTangent.Checked) { findOvalue += tangent; }
        if (cbxNearest.Checked) { findOvalue += nearest; }
        if (cbxApparent.Checked) { findOvalue  += apparentIntersection; }
        if (cbxExtension.Checked) { findOvalue += extension; }
        if (cbxParallel.Checked) { findOvalue += parallel; }
        if (cbxNone.Checked) { findOvalue = 0; }
        // Right Click values
        int defaultmode = 1;
        int editmode = 2;
        int commandactive = 4;
        int commandmode = 8;
        int menumode = 16;
        // find the right click value
        if (cbxRcDefault.Checked) { findMvalue += defaultmode; }
        if (cbxRcEdit.Checked) { findMvalue += editmode; }
        if (cbxRcCommandActive.Checked) { findMvalue += commandactive; }
        if (cbxRcCommand.Checked) { findMvalue += commandmode; }
        if (cbxRcMenu.Checked) { findMvalue += menumode; }
        // the value of the slider location.  3 to 100
        int zfValue = tbZoomFactor.Value;
        // file dialog
        int fdval = 0;
        if (cbxFileDialog.Checked) fdval = 1;
        // pick first
        int pfval = 0;
        if (cbxPickFirst.Checked) pfval = 1;
        // middle button pan
        int mbval = 0;
        if (cbxMbuttonPan.Checked) mbval = 1;
        // attribute required
        int attval = 0;
        if (cbxAttRequired.Checked) attval = 1;
        // paperspace background color
        int psval = 0;
        if (cbxPsBackground.Checked) psval = 256;
        string nL = Environment.NewLine;
        string ppValue = tbPromptPrefix.Text;
        System.IO.StreamWriter file = new System.IO.StreamWriter(@"N:\C3D Support\MySettings.txt");
        file.WriteLine("OSMODE," + findOvalue + nL + "SHORTCUTMENU," + findMvalue + nL + "ZOOMFACTOR," + zfValue + nL + "FILEDIA," + fdval + nL + "PICKFIRST," + pfval + nL + "MBUTTONPAN," + mbval + nL + "ATTREQ," + attval + nL + "BKGCOLORPS," + psval + nL + "CMDLNTEXT," + ppValue);
        file.Close();
    }
