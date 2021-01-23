    if (_host != null) // make sure widget is being used inside a PageBuilder page
        {
            var p = this.Page as PageBuilder; // get PageBuilder object
            if (p.Status == Mode.Editing) // check for Editing mode
            {
                 ux.Visible = true //Display UX
            }
        }
