    private void button1_Click(object sender, EventArgs e)
    {
        ROOM.ADD_ROOM(TXT_ROOM_NAME.Text, 
                      Convert.ToInt32(TXT_ROOM_SIZE.Text), 
                      CHECK_LAB.Checked);
    
        MessageBox.Show(" The Room has been added successfully", "ADD PROCEDURE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.dataGridView1.DataSource = ROOM_VIEW.GET_ALL_ROOMS();
    }
