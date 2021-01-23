    public bookItem()
    {
        InitializeComponent();
    }
    public bookItem(DataGridViewRow bookData)
    {
        InitializeComponent();
        label1.Text = bookData.Cells[0].FormattedValue.ToString();
        label2.Text = bookData.Cells[1].FormattedValue.ToString();
        label3.Text = bookData.Cells[2].FormattedValue.ToString();
        label4.Text = bookData.Cells[3].FormattedValue.ToString();
    }
