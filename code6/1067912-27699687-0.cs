    // You Can Use Key Down method here
    private void tb_Kategorie_KeyDown(object sender, KeyEventArgs e)
    {
        MessageBox.Show("works");
        if (e.KeyCode==  Keys.Enter || e.KeyCode== Keys.Return)
        {
    
            tb_Ort.Focus();
        }
        else if (e.KeyCode==  Keys.Escape)
        {
            tb_Kategorie.Text = escSpeicher;
            tb_Kategorie.SelectAll();
        }
    }
