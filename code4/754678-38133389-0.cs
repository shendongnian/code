    // Fires EVERY time ANY mouse button moves down
    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
    Console.WriteLine("MouseDown Event: " +  e.Button + " button." );
    }
    
    
    // Fires when the LEFT mouse button is double clicked
    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
    Console.WriteLine(" CellDoubleClick: LEFT Button was double clicked");
    }
    
    
    
    // Fires when ANY mouse button is double clicked
    private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
    Console.WriteLine(" CellMouseDoubleClick Event: SOME Button was double clicked");
    }
