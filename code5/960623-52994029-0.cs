    public string getCPUTemp()
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.CPUEnabled = true;
                computer.Accept(updateVisitor);
                string res = "";
                for (int i = 0; i < computer.Hardware.Length; i++)
    
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.CPU)
    
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
    
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature) res = String.Concat(res, (computer.Hardware[i].Sensors[j].Name + ": " + computer.Hardware[i].Sensors[j].Value.ToString() + "ºC" + "\r"));
                            if (computer.Hardware[i].Sensors[j].Value.ToString() == "") { res = ""; return res; }
                        }
    
                    }
                }
