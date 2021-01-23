        public ActionResult DisplayForm()
        {
            FormModel frmmdl = new FormModel();
            TryUpdateModel (frmmdl);
            // Your model should now be populated
        }
