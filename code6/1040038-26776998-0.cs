    try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to cancel all unsaved changes?", "Cancel all unsaved changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bindingSource1 = bindingSource1.Where(bs => (bs as MyConfiguration).MyConfigurationId != 0);//.ToList(); if needed
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
