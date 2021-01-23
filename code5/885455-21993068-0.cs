    public class Dlg
    {
       public delegate void UpdateConnLabel(string txt);
       private event UpdateConnLabel _UpdateConnLabel;
            
       public Dlg()
       {
          InitializeComponent();
          _UpdateConnLabel = new UpdateConnLabel(DoUpdateConnectionLabel);
       }
                        
       public void UpdateConnectionLabel(String txt)
       {
          this.Invoke(_UpdateConnLabel, new object[] { txt });
       }
               
       private void DoUpdateConnectionLabel(string txt)
       {
          label_connection.Text = txt;
       }
        
    }
