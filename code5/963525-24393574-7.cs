    public Form1()
    {
        InitializeComponent();
        indicatorPanel.Width = 5;
        indicatorPanel.Height = 10;
        indicatorPanel.BackColor = Color.Red;
        dataGridView1.Controls.Add(indicatorPanel);
        indicatorPanel.Left = dataGridView1.Width - 5;
        indicatorPanel.Top = -10;  //hide at first
        indicatorPanel.BringToFront();
    }
    int targetRow= -1;
    Panel indicatorPanel = new Panel();
    // call in: dataGridView1_RowsRemoved, dataGridView1_RowsAdded
    void setPosition()
    {
        if (targetRow < 0) return;
        indicatorPanel.Top = 10 + (int) (1f * (dataGridView1.ClientSize.Height - 25) 
                                            * targetRow / dataGridView1.Rows.Count);  //**
    }
    // call to set the row you want to mark
    void setTarget(int tRow)
    {
       // for testing only: mark the row and clear the old mark:
       dataGridView1.Rows[targetRow].Cells[0].Style.BackColor = Color.Silver;  // test
       dataGridView1.Rows[tRow].Cells[0].Style.BackColor = Color.Red;          // test
       targetRow= tRow;
       indicatorPanel.Visible = (targetRow >= 0);
       setPosition();
    }
