    private void button1_Click(object sender, EventArgs e)
            {               
               
    if (CHECK_LAB.Checked)
    {
    
    ROOM.ADD_ROOM(TXT_ROOM_NAME.Text,int.Parse(TXT_ROOM_SIZE.Text),Convert.ToInt32(1));
    
    }
        else
    {
    
       ROOM.ADD_ROOM(TXT_ROOM_NAME.Text, Convert.ToInt32(TXT_ROOM_SIZE.Text), Convert.ToInt32(0));              }
