    try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to cancel all unsaved changes?", "Cancel all unsaved changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (MyConfiguration f in bindingSource1.Select(bs => bs as MyConfiguration).Where(bs => bs.MyConfigurationId == 0))
                    {
                            context.RemoveMyConfiguration(f);
                            bindingSource1.Remove(f);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
