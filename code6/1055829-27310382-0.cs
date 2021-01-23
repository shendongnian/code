    public static class FormHelper
    {
        public static TForm ShowAndActivate<TForm>(TForm form) where TForm : Form, new()
        {
            if (form == null || form.IsDisposed)
            {
                form = new TForm();
                form.Show();
            }
            else
            {
                if (!form.Visible)
                {
                    form.Show();
                    form.Activate();
                }
                else
                {
                    form.Activate();
                }
            }
            return form;
        }
    }
