        private void timer1_Tick(object sender, EventArgs e)
        {
			IPAddress address = IPAddress.Parse(tbIP.Text);
			int port = Convert.ToInt32(tbPort.Text);
			slaveTcpListener = new TcpListener(address, port);
			slave = ModbusTcpSlave.CreateTcp(1, slaveTcpListener);
			DataStore data = new DataStore();
			for (int i=0; i<dgV.Rows.Count-1; i++)
			{ 
				slave.DataStore.InputRegisters[Convert.ToInt32(dgV[0,i].Value)] = (ushort)Convert.ToUInt16(dgV[1,i].Value);
			} 
			slave.Listen();
        }
