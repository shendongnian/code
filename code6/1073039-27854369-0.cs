     public CheckBox[] chk;
     chk[i] = new CheckBox();
     chk[i].ID = "chk" + dt1.Rows[i]["SubjectName"].ToString();
     chk[i].Text = dt1.Rows[i]["SubjectName"].ToString();                   
     chk[i].CheckedChanged += WebForm1_CheckedChanged;
     PanelSubject.Controls.Add(chk[i]);
    
    
     void WebForm1_CheckedChanged(object sender, EventArgs e)
     {
          throw new NotImplementedException();
     }
