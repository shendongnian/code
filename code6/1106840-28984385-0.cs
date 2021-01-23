    using System.Windows.Forms; //You need this statement.
    namespace example
    {
     class Utilities
     {
        public static void ResetAllControls(Mainform form)
        {
            foreach (Mainform control in form.Controls)
            {
                if (form is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }
            }
        }    
     }
    }
