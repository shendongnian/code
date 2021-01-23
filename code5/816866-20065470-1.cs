            void clearText(Control control)
            {
                foreach (Control c in control.Controls)
                {
                    if (c is TextBox)
                        ((TextBox)c).Clear();
                    else
                        clearText(c);
                }
            }
            public void ModifyControl<T>(Control root, Action<T> action) where T : Control
            {
                if (root is T)
                    action((T)root);
                // Call ModifyControl on all child controls
                foreach (Control control in root.Controls)
                    ModifyControl<T>(control, action);
            }
            private void button5_Click(object sender, System.EventArgs e)
            {
               clearText(this);
               ModifyControl<TextBox>(splitContainer1, tb => tb.Text = "");
            }
