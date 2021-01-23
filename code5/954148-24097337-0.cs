      protected void Page_Load(object sender, EventArgs e)
            {
                var newListBox = new ListBox();
                newListBox.ID = "ANewId";
                newListBox.Items.Add("1");
                newListBox.Items.Add("2");
                newListBox.SelectedIndexChanged += LstBoxChanged;
                Panel1.Controls.Add(newListBox);
            }
    
            private void LstBoxChanged(object sender, EventArgs e)
            {
                var newListBox = sender as ListBox;
    
                if (newListBox != null && newListBox.SelectedItem != null)
                {
                    Label1.Text = newListBox.SelectedItem.Text;
                }
            }     
