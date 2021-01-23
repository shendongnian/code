    private void edit_Click(object sender, EventArgs e)
    {
        MyClass item = listBox1.SelectedItem as MyClass;
        if(item != null)
        {
             Form3 MyForm = new Form3();
             MyForm.Owner = this;
             MyForm.ItemToEdit = item;
             MyForm.Show();
        }
    }
