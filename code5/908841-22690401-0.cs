    private void btn_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if(button != null)
             MessageBox.Show(button.Text);
    }
