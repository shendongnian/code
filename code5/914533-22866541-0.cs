    class FormInputControl
    {
         public string Description { get; set; } //Every form input has a description like User, link, what you want that form input control instance to describe
         public abstract object Value { get; set; }
    }
    
    class InputBox : FormInputControl
    {
         public string Text { get; set; }
         public overwrite object Value
         {
             get { return Text; }
             set { Text = value as string; }
         }
    }
    
    
    class Form
    {
         public IList<FormInputControls> { get; set; }
    }
