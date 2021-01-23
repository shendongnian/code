        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if(condition)//condition is when you show your checkbox
            {
                txt.Visible = true;
                lblTest.Visible = false;
            }
            else
            {
                lblTest.Visible = true;
                txt.Visible = false;
            }
        }
