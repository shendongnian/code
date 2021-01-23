     foreach (RepeaterItem item in repeatername.Items)
            {
              ((TextBox)item.FindControl("tbxKey")).Text = "hello";
              ((LinkButton) item.FindControl("LinkButton")).Enabled = false;
            }
