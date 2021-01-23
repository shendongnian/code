        TextBox txt;
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            txt = new TextBox();
            txt.ID = "textBoxTest";
            txt.Visible = false;
            pnlButtons.add(txt); // till now pnlButtons should be created because you call first for base.CreateChildControls
        }
