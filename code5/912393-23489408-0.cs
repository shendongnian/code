            Button btn = new Button();
            Label lbl = new Label();
            CustomControl cst_btn = new CustomControl(btn, lbl);
            cst_btn = sender as CustomControl;
            DialogResult dialogResult = MessageBox.Show("Are you sure that you want to remove this object?", "Remove object", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                cst_btn.Dispose();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }
        public EventHandler handlerGetter(CustomControl button)
        {
            return (object sender, EventArgs e) =>
            {
                rmv_btn_click(button, e);
            };
        }
