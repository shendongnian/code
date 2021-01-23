    public class MainForm
    {
       public string LoginName { get; set; }
           
       public void ShowChildForm()
       {
          var childForm = new ChildForm(this);
          childForm.Show();
       }
    }
    
