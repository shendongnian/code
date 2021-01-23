        public override string ToString()
        {
            byte[] SerialNumber;
            ReadSerialNumber(out SerialNumber);
            string SerialNumberString = "Serial Number = " + Encoding.Unicode.GetString(SerialNumber);
            if (SerialNumberString[0] == '\0')
            {
                return string.Format("VendorID={0}, ProductID={1}, Version={2}, DevicePath={3}",
                                    _deviceAttributes.VendorHexId,
                                    _deviceAttributes.ProductHexId,
                                    _deviceAttributes.Version,
                                    _devicePath);
            }
            else
            {
                return SerialNumberString;
            }
        }
