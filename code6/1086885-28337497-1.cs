     public object ReturnCircle(Point pt,double rad)
      {
        Point center=pt;
        if (rbCircle.Checked==true)
        {
            pt.x = double.Parse(txtCirCntPtX.Text.Trim());
            pt.y = double.Parse(txtCirCntPtY.Text.Trim());
            rad = double.Parse(txtCirRadius.Text.Trim());
         }
        return this.Init_Circle(pt,rad);
    }
