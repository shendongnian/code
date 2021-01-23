      class Helper
       {
        public void SetRedColorToTextBoxes(Form frm)
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).BackColor = Color.Red;
                    else
                        func(control.Controls);
            };
            func(frm.Controls);
        }
    }
