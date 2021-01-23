    private void new_btn_Click(object sender, EventArgs e)
    {
        var cell1 = "";
        var cell2 = "";
        Form2 Form2 = new Form2(cell1, cell2);
        Form2.FormClosed += Form2HasBeenClosed;
        Form2.Show();
    }
    private void Form2HasBeenClosed(object sender, FormClosedEventArgs e)
    {
        // Inside the form1 call your RefreshGridView
    }
    
