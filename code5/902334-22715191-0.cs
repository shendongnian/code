    private void InitializeSerialPort()
            {
                try
                {
                    String ComPortName = ComPortCB.Text;
                    ComPortName = ComPortName.Trim();
                    _serialPort = new SerialPort(ComPortName, 115200, Parity.None, 8, StopBits.One);
                    _serialPort.Handshake = Handshake.None;
                    _serialPort.WriteTimeout = 500;
                    _serialPort.ReadTimeout = 500;
                    _serialPort.Open();
                    _serialPort.Close();
                    _SerialPortInitialization = true;
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
    
    public static void StartStepperMotor()
            {
                try
                {
                    if (!_serialPort.IsOpen)
                        _serialPort.Open();
    
                    byte[] StartMotorRequest = new byte[] { 0xff, 0x04, 0x30, 0xcd };
                    byte[] SetParamTargetPosition = new byte[] { 0xFF, 0x09, 0x13, 0x08, 0x00, 0x50, 0xC3, 0x00, 0xCA };
    
                    byte[] GetDataItems;
                    GetDataItems = new byte[] { 0xff, 0x06, 0x13, 0x1e, 0x00, 0xca };
                    _serialPort.Write(GetDataItems, 0, GetDataItems.Length);
    
                    _serialPort.Write(StartMotorRequest, 0, StartMotorRequest.Length);
                    _serialPort.Write(SetParamTargetPosition, 0, SetParamTargetPosition.Length);
                    //_serialPort.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
                }
            }
    
    public static void StopStepperMotor()
            {
                try
                {
                    if (!_serialPort.IsOpen)
                        _serialPort.Open();
    
                    byte[] StopMotorRequest = new byte[] { 0xff, 0x04, 0x31, 0xcc };
                    _serialPort.Write(StopMotorRequest, 0, StopMotorRequest.Length);
                    //_serialPort.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
                }
            }
    
    private void RotateStepperMotor(int RequiredAngle)
        {
            try
            {
                if (!_serialPort.IsOpen)
                    _serialPort.Open();
                ushort Steps = RequiredAngle;
                byte TargetPositionLSB = (byte)(Steps & 0xFFu);
                byte TargetPositionMSB = (byte)((Steps >> 8) & 0xFFu);
                byte CheckSumByte;
                CheckSumByte = (byte)(0 - (0xFF + 0x09 + 0x13 + 0x08 + TargetPositionLSB + TargetPositionMSB));
                byte[] GetDataItems;
                GetDataItems = new byte[] { 0xff, 0x06, 0x13, 0x1e, 0x00, 0xca };
                _serialPort.Write(GetDataItems, 0, GetDataItems.Length);
                byte[] StartMotorRequest = new byte[] { 0xff, 0x04, 0x30, 0xcd };
                byte[] SetParamTargetPosition = new byte[] { 0xFF, 0x09, 0x13, 0x08, 0x00, TargetPositionLSB, TargetPositionMSB, 0x00, CheckSumByte };
                _serialPort.Write(StartMotorRequest, 0, StartMotorRequest.Length);
                _serialPort.Write(SetParamTargetPosition, 0, SetParamTargetPosition.Length);
                _serialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");
            }
        }
