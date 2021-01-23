    public abstract class BaseControl : UserControl
    {
      public T GetControlByType<T>(Func<T, bool> predicate = null) where T : Control
      {
        var stack = new Stack<Control>(new Control[] { this });
        while (stack.Count > 0)
        {
          var control = stack.Pop();
          T match = control as T;
          if (match != null)
          {
            if (predicate == null || predicate(match))
            {
              return match;
            }
          }
          foreach (Control childControl in control.Controls)
          {
            stack.Push(childControl);
          }
        }
        return default(T);
      }    
  
      public TextBox FirstName
      {
        get { return GetControlByType<TextBox>(t => t.ID == "txtFirstName"); }
      }
      public void SomeLogicExample() 
      {
        FirstName.Text = "Something"; 
      }
    }
