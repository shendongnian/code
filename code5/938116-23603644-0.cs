    class Categoty_uc
    {
      public event EventHandler ButtonClicked;
    
      protected OnButtonClicked()
      {
        var tmp = ButtonClicked;
        
        if(tmp != null)
        {
          tmp(this, EventArgs.Empty);
        }
      }
    
      private void btn_categorySave_Click(object sender, EventArgs e)
      {
        OnButtonClicked();
      }
    }
