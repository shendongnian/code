        private void AddControl(string control)
        {
            if (control == "Textbox")
            {
                TextBox tb = new TextBox();
                tb.Location = new Point(100, 100);
                this.Controls.Add(tb);
            }
            else if (control == "Radio")
            {
                RadioButton rb = new RadioButton();
                rb.Location = new Point(200, 100);
                this.Controls.Add(rb);
            }
        }
