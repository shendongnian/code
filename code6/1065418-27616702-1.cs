    public void SetBackground(Control.ControlCollection coll)
    {
        foreach(Control ctr in coll)
        {
           if(ctr.Controls.Count > 0)
              SetBackground(ctr.Controls);
           else
           {
              Button btn = ctr as Button;
              if(btn != null) btn.BackColor = Color.Black;
           }
        }
    }
