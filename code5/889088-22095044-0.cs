        protected void ApplyAssociation(object sender, EventArgs e)
        {
            //Some piece of code
            if (a == 0)
            {
                ButtonAssociateRules.Style["visibility"] = "hidden";
                ButtonReplaceId.Style["visibility"] = "hidden";
                myUpdatePanel.Update();
            }
        }
        protected void ApplyAssociation(object sender, EventArgs e)
        {
            //Some piece of code
            if (a == 0)
            {
                ButtonAssociateRules.Visible = false;
                ButtonReplaceId.Visible = false;
                myUpdatePanel.Update();
            }
        }
