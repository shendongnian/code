 private void txtParciales_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtParciales.Text, @"\d+(\.\d{2,2})"))
                e.Handled = true;
            else e.Handled = false;
        }</code></pre>
