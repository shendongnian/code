    FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm != null)
                {
                    foreach (TextBox txt in frm.Controls)
                    {
                        if (txt.Focused)
                        {
                            txt.Text = "your text";
                        }
                    }
                }
            }
