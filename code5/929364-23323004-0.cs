        public IEnumerable<Control> GetAll(Control control)
         {        
           var controls = control.Controls.Cast<Control>();
        
           return controls.SelectMany(ctrl => GetAll(ctrl))
           .Concat(controls)
           .Where(c => c.Visible == true);
    //If you don't need to check that the control's visibility then simply ignore the where clause..
        
         }
