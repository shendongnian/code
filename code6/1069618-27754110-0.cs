    private void Form1_Load(object sender, EventArgs e)
    {
        // create a few Label with varying Colors for testing..
        fillFLP(FLP1, 88);
        fillFLP(FLP2, 111);
    }
    void fillFLP(FlowLayoutPanel FLP, int cc)
    {
        for (int i = 0; i < 24; i++)
        {
            Label l = new Label();
            // the next 3 lines optional and only are there for testing!
            l.AutoSize = false;      
            l.Text = FLP.Name + " " +  i.ToString("00");
            l.BackColor = Color.FromArgb(255, cc * 2 - i, 255 - 5 * i, cc + 5 * i); 
            // add controls and set mouse events:
            FLP.Controls.Add(l);
            l.MouseDown += l_MouseDown;
            l.MouseUp += l_MouseUp;
            l.MouseMove += l_MouseMove;
        }
    }
    // the currently moved Label:
    Label mvLabel = null;
    void l_MouseDown(object sender, MouseEventArgs e)
    {
        // keep reference
        mvLabel = (Label)sender;
    }
        
    void l_MouseMove(object sender, MouseEventArgs e)
    {
        // if we are dragging a label:
        if (mvLabel != null)
        {
            // mouse pos in window coords
            Point  mvPoint = this.PointToClient(Control.MousePosition);
            // the label is still in the FLP, so we start the drg action:
            if (mvLabel.Parent != this)
            {
                mvLabel.Parent = this;
                mvLabel.Location = mvPoint;
                mvLabel.BringToFront();
            }
            else
            {   
                // we are already in the form, so we just move
                mvLabel.Location = mvPoint;
            }
        }
    }
    void l_MouseUp(object sender, MouseEventArgs e)
    {
        // are we over a FLP? and if so which?
        Point MP = Control.MousePosition;
        FlowLayoutPanel FLP = null;
        Point mLoc1 = FLP1.PointToClient(MP);
        Point mLoc2 = FLP2.PointToClient(MP);
        if (FLP1.ClientRectangle.Contains(mLoc1)) FLP = FLP1;
        else if (FLP2.ClientRectangle.Contains(mLoc2)) FLP = FLP2;
        else return;  // no! nothing we can do..
        // yes, now find out if we are over a label..
        // ..or over an empty area
        mvLabel.SendToBack();
        Control cc = FLP.GetChildAtPoint(FLP.PointToClient(MP));
        // if we are over the FLP we can insert at the beginning or the end:
        // int mvIndex = 0; // to the beginning
        int mvIndex = FLP.Controls.Count; // to the end
        // we are over a Label, so we insert before it:
        if (cc != null) mvIndex = FLP.Controls.IndexOf(cc);
        // move the Label into the FLP
        FLP.Controls.Add(mvLabel);
        // move it to the right position:
        FLP.Controls.SetChildIndex(mvLabel, mvIndex);
        // let go of the reference
        mvLabel = null;
    }
