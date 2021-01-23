    public class form1
    {
       private myModel model;
       
       public form()
       {
          Initialize();
       }
       
       private void Initialize()
       {
          model.OnNameChanged += new EventHandler(model_OnNameChangedEvent);
       }
    
       private void model_OnNamedChangedEvent(object sender, NameChangedEventArgs e)
       {
          textbox.text = e.Name;
       }
    }
