    using (TcpClient client = new TcpClient(device.ip, 502))
    {
        try 
        {
            using (Modbus.Device.ModbusIpMaster master = Modbus.Device.ModbusIpMaster.CreateIp(client))
            {
                master.WriteMultipleRegisters(500, new ushort[] { 0xFF80 });
            }
        }
        catch(Exception e) 
        {
            // Log exception
        }
        finally 
        {
            client.Close();
        }
    }
