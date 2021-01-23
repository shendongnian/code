        List<byte> MCUDataOverTime = new List<byte>();        
        private void SerialPc_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPc.DiscardNull = false;
            SerialPc.Read(MCUData, 0, 16);
            MCUDataOverTime.AddRange(MCUData);
            SerialPc.ReceivedBytesThreshold = 16;
            DataGreedByteValueShow();
        }
        private void DataGreedByteValueShow()
        {
            if (MCUDataOverTime.Count >= 16)
            {
                dataGridView1.Rows[0].Cells[1].Value = MCUDataOverTime[0];
                dataGridView1.Rows[1].Cells[1].Value = MCUDataOverTime[1];
                dataGridView1.Rows[2].Cells[1].Value = MCUDataOverTime[2];
                dataGridView1.Rows[3].Cells[1].Value = MCUDataOverTime[3];
                dataGridView1.Rows[4].Cells[1].Value = MCUDataOverTime[4];
                dataGridView1.Rows[5].Cells[1].Value = MCUDataOverTime[5];
                dataGridView1.Rows[6].Cells[1].Value = MCUDataOverTime[6];
                dataGridView1.Rows[7].Cells[1].Value = MCUDataOverTime[7];
                dataGridView1.Rows[8].Cells[1].Value = MCUDataOverTime[8];
                dataGridView1.Rows[9].Cells[1].Value = MCUDataOverTime[9];
                dataGridView1.Rows[10].Cells[1].Value = MCUDataOverTime[10];
                dataGridView1.Rows[11].Cells[1].Value = MCUDataOverTime[11];
                dataGridView1.Rows[12].Cells[1].Value = MCUDataOverTime[12];
                dataGridView1.Rows[13].Cells[1].Value = MCUDataOverTime[13];
                dataGridView1.Rows[14].Cells[1].Value = MCUDataOverTime[14];
                dataGridView1.Rows[15].Cells[1].Value = MCUDataOverTime[15];
            }
        }
