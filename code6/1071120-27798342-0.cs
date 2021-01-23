    public abstract class BaseControl : UserControl
    {
      public abstract TextBox FirstName { get; }
      public void SomeLogicExample() 
      {
        FirstName.Text = "Something"; 
      }
    }
    public class ControlA : BaseControl
    {
      public override TextBox FirstName
      {
        // txtFirstNameA is ID of TextBox, so it is defined in ControlA.designer.cs
        get { return txtFirstNameA; }
      }
    }
    public class ControlB : BaseControl
    {
      public override TextBox FirstName
      {
        // txtFirstNameB is ID of TextBox, so it is defined in ControlB.designer.cs
        get { return txtFirstNameB; }
      }
    }
