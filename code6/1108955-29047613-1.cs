    TextBox EditCell = new TextBox();
    public Form1()
    {
        InitializeComponent();
        //..
        EditCell.TextChanged += EditCell_TextChanged;
        EditCell.Leave += EditCell_Leave;
        EditCell.KeyDown += EditCell_KeyDown;
    }
    void EditCell_TextChanged(object sender, EventArgs e)
    {
        yourLabel.Text = EditCell.Text;
    }
    void EditCell_Leave(object sender, EventArgs e)
    {
        ListViewItem lvi = EditCell.Tag as ListViewItem;
        if (lvi != null)   lvi.Text = EditCell.Text;
        EditCell.Hide();
    }
    void EditCell_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) 
        { 
            e.Handled = true; 
            EditCell_Leave(null, null);
        }
        else if (e.KeyCode == Keys.Escape)
        {
            e.Handled = true;
            EditCell.Tag = null;
            EditCell_Leave(null, null);
        }
        e.Handled = false;
    }
    private void listView1_BeforeLabelEdit(object sender, LabelEditEventArgs e)
    {
        // stop editing the item!
        e.CancelEdit = true;
        ListViewItem lvi = listView1.Items[e.Item];
        EditCell.Parent = listView1;
        EditCell.Tag = lvi;
        EditCell.Bounds = lvi.Bounds;
        EditCell.BackColor = Color.WhiteSmoke;  // suit your taste!
        EditCell.Text = lvi.Text;
        EditCell.Show();
        EditCell.SelectionStart = 0;
        EditCell.Focus();
        EditCell.Multiline = true;  // needed to allow enter key
    }
