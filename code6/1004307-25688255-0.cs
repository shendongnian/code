    private void spinEdit1_Properties_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
    {
        if (e.IsSpinUp)
        {
            spinEdit1.EditValue = 4800;
            e.Handled = true;
        }
        else
        {
            spinEdit1.EditValue = 2400;
            e.Handled = true;
        }
    }
