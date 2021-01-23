       public partial class FormSO29381768 : Form
       {
          // Constructor
          public FormSO29381768()
          {
             InitializeComponent();
    
             InstallEventHandlers(this);
          }
    
    
          /// <summary>
          /// Recursive method to install the paint event handler for all container controls on a form, 
          /// including the form itself, and also to install the "enter" event handler for all controls 
          /// on a form.
          /// </summary>
          private void InstallEventHandlers(Control containerControl)
          {
             containerControl.Paint -= Control_Paint;  // Defensive programming
             containerControl.Paint += Control_Paint;
             
             foreach (Control nestedControl in containerControl.Controls)
             {
                nestedControl.Enter -= Control_ReceivedFocus;  // Defensive programming
                nestedControl.Enter += Control_ReceivedFocus;
    
                if (nestedControl is ScrollableControl)
                   InstallEventHandlers(nestedControl);
             }
          }
    
    
          /// <summary>
          /// Event handler method that gets called when a control receives focus. This just indicates 
          /// that the whole form needs to be redrawn. (This is a bit inefficient, but will presumably 
          /// only be noticeable if there are many, many controls on the form.)
          /// </summary>
          private void Control_ReceivedFocus(object sender, EventArgs e)
          {
             this.Refresh();
          }
    
    
          /// <summary>
          /// Event handler method to draw a dark blue rectangle around a control if it has focus, and 
          /// if it is in the container control that is invoking this method.
          /// </summary>
          private void Control_Paint(object sender, PaintEventArgs e)
          {
             Control activeControl = this.ActiveControl;
             if (activeControl != null && activeControl.Parent == sender) 
             {
                e.Graphics.DrawRectangle(Pens.DarkBlue, 
                            new Rectangle(activeControl.Location.X - 2, activeControl.Location.Y - 2, 
                                          activeControl.Size.Width + 4, activeControl.Size.Height + 4));
             }
          }
       }
