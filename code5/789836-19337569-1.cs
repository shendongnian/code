    if(Convert.ToInt32(txtTemp.Text)>15 )
    {
      lbl.Text= "HOT";
      lbl.ForeColor= System.Drawing.Color.Red;
    }
    else
    {
        lbl.Text="COLD";
             lbl.ForeColor= System.Drawing.Color.Blue;
    }
