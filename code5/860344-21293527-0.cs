    public void ShowForm()
    {
        var a = hmf.ShowDialog();
        if (a == DialogResult.OK) {
            MessageBox.Show("DialogResultOK was hit.");
            // store winforms values into global vars
            try
            {
                MessageBox.Show(Params.Input[0].ToString());
                Grasshopper.Kernel.Parameters.Param_String param = (Grasshopper.Kernel.Parameters.Param_String)Params.Input[0];
                param.PersistentData.Clear();
                for (int i = 0; i <= x.Count - 1; i++)
                {
                    param.PersistentData.Append(new GH_String(x[i]));
                }
                param.ExpireSolution(true);
            }
            catch (Exception ex)
            {
                // error message
            }
        }
        else if (a == DialogResult.Cancel)
        {
            MessageBox.Show("DialogResultCancel was hit.");
            this.ExpireSolution(false);
        }
    }
