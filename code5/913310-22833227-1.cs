    private void frmMain_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(MyControl1)) || e.Data.GetDataPresent(typeof(MyControl2)) || e.Data.GetDataPresent(typeof(MyControl3)))
            e.Effect = DragDropEffects.Move;
        else e.Effect = DragDropEffects.None;
    }
    private void frmMain_DragOver(object sender, DragEventArgs e)
    {
        Point DragTarget = new Point(e.X, e.Y);
        Point GrabPoint = new Point(0, 0);
        if (e.Data.GetDataPresent(typeof(MyControl1)))
            GrabPoint = ((MyControl1)e.Data.GetData(typeof(MyControl1))).GrabPoint;
        else if (e.Data.GetDataPresent(typeof(MyControl2)))
            GrabPoint = ((MyControl2)e.Data.GetData(typeof(MyControl2))).GrabPoint;
        else if (e.Data.GetDataPresent(typeof(MyControl3)))
            GrabPoint = ((MyControl3)e.Data.GetData(typeof(MyControl3))).GrabPoint;
        DragTarget.X -= GrabPoint.X;
        DragTarget.Y -= GrabPoint.Y;
        DragTarget = this.PointToClient(DragTarget);
        if (e.Data.GetDataPresent(typeof(MyControl1)))
            ((MyControl1)e.Data.GetData(typeof(MyControl1))).Location = DragTarget;
        else if (e.Data.GetDataPresent(typeof(MyControl2)))
            ((MyControl2)e.Data.GetData(typeof(MyControl2))).Location = DragTarget;
        else if (e.Data.GetDataPresent(typeof(MyControl3)))
            ((MyControl3)e.Data.GetData(typeof(MyControl3))).Location = DragTarget;
    }
