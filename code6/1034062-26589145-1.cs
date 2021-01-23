    private void dataGridView1_DragDrop(object sender, DragEventArgs e)
    {
    	Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
    	DataGridView.HitTestInfo hti = dataGridView1.HitTest(clientPoint.X, clientPoint.Y);
    	DataGridViewCell targetCell = dataGridView1[hti.ColumnIndex, hti.RowIndex];
    
    	targetCell.Value = e.Data.GetData(DataFormats.Text).ToString().Split(' ')[1];	//for GridCell
    	
    	textBox3.Text = e.Data.GetData("System.String").ToString().Split()[0];	//for TextBox
    }
