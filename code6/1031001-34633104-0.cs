    static void sensor_DataUpdated(Sensor sensor, SensorDataReport dataReport)
    {
        SensorData data = new SensorData(sensor, dataReport);
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            socket.Send(data.ToByteArray());
        }
    }
    
