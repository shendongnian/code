        if (e.Control && e.KeyCode == Keys.Space)
        {
           
            if (e.Control && e.KeyCode == Keys.Space)
            {
                int a;
                frmProducts cs = new frmProducts();
                cs.ShowDialog();
                a = cs.fnc_selectbtncCode();
                txtProductCode1.Text = Convert.ToString(a);
            }
        }
        if (e.KeyCode == Keys.Enter)
        {
            txtQty.Focus();
        }          
    }
