    private void timer1_Tick(object sender, EventArgs e)
    {
        Countername++;
        switch (Countername)
        {
            case 1:
                PS3.SetMemory((0x01786718 + (uint)dataGridView1.CurrentRow.Index * 0x5808), new byte[] { 0x01 });//Go Prone
                break;
                    
            case 2:
                PS3.SetMemory((0x01786718 + (uint)dataGridView1.CurrentRow.Index * 0x5808), new byte[] { 0x00 });//Stand Up
                if (Countername == 2)
                    Countername = 0;
                    
                break;
        }
    }
