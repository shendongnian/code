    protected override void OnPreRender(EventArgs e)
            {
                var master = this.Page.Master as Site;
                if (master != null)  // cast failed, your master is a different type
                {
                    var progressShown = master.FindControl("ProgressShown");
                    if (progressShown != null)
                    {
                        master.NavBar.Attributes.Add("class", "test");
                    }
                }
    
                base.OnPreRender(e);
            }
