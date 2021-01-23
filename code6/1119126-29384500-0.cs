       public partial class FormSO29381768 : Form
       {
          // Constructor
          public FormSO29381768()
          {
             InitializeComponent();
    
             InstallFocusChangeEventHandler(this.Controls);
             InstallPaintHandler(this);
          }
    
    
          /// <summary>
          /// Recursive method to install the "enter" event handler for all controls on a form.
          /// </summary>
          private void InstallFocusChangeEventHandler(IEnumerable controls)
          {
             foreach (Control control in controls)
             {
                control.Enter -= Control_ReceivedFocus;  // Defensive programming
                control.Enter += Control_ReceivedFocus;
                InstallFocusChangeEventHandler(control.Controls);
             }
          }
    
    
          /// <summary>
          /// Recursive method to install the paint event handler for all container controls on a form, 
          /// including the form itself.
          /// </summary>
          private void InstallPaintHandler(Control control)
          {
             control.Paint -= Control_Paint;  // Defensive programming
             control.Paint += Control_Paint;
             
             foreach (Control nestedControl in control.Controls)
             {
                if (nestedControl is ScrollableControl)
                   InstallPaintHandler(nestedControl);
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
             Control containerControl = sender as ScrollableControl;
             Control activeControl = this.ActiveControl;
             if (activeControl != null && activeControl.Parent == containerControl) 
             {
                e.Graphics.DrawRectangle(Pens.DarkBlue, 
                            new Rectangle(activeControl.Location.X - 2, activeControl.Location.Y - 2, 
                                          activeControl.Size.Width + 4, activeControl.Size.Height + 4));
             }
          }
       }
