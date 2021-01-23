    foreach (var display in DisplayDetails.GetMonitorDetails())
    {
        Console.WriteLine(display.Model);
    }
    public class DisplayDetails
    {
        public string PnPID { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string MonitorID { get; set; }
        /// <summary>
        /// The Constructor to create a new instances of the DisplayDetails class...
        /// </summary>
        public DisplayDetails(string sPnPID, string sSerialNumber, string sModel, string sMonitorID)
        {
            PnPID = sPnPID;
            SerialNumber = sSerialNumber;
            Model = sModel;
            MonitorID = sMonitorID;
        }
        /// <summary>
        /// This Function returns all Monitor Details
        /// </summary>
        /// <returns></returns>
        static public IEnumerable<DisplayDetails> GetMonitorDetails()
        {
            //Open the Display Reg-Key
            RegistryKey Display = Registry.LocalMachine;
            Boolean bFailed = false;
            try
            {
                Display = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\DISPLAY");
            }
            catch
            {
                bFailed = true;
            }
            if (!bFailed & (Display != null))
            {
                //Get all MonitorIDss
                foreach (string sMonitorID in Display.GetSubKeyNames())
                {
                    RegistryKey MonitorID = Display.OpenSubKey(sMonitorID);
                    if (MonitorID != null)
                    {
                        //Get all Plug&Play ID's
                        foreach (string sPNPID in MonitorID.GetSubKeyNames())
                        {
                            RegistryKey PnPID = MonitorID.OpenSubKey(sPNPID);
                            if (PnPID != null)
                            {
                                string[] sSubkeys = PnPID.GetSubKeyNames();
                                //Check if Monitor is active
                                if (sSubkeys.Contains("Control"))
                                {
                                    if (sSubkeys.Contains("Device Parameters"))
                                    {
                                        RegistryKey DevParam = PnPID.OpenSubKey("Device Parameters");
                                        string sSerial = "";
                                        string sModel = "";
                                        //Define Search Keys
                                        string sSerFind = new string(new char[] { (char)00, (char)00, (char)00, (char)0xff });
                                        string sModFind = new string(new char[] { (char)00, (char)00, (char)00, (char)0xfc });
                                        //Get the EDID code
                                        byte[] bObj = DevParam.GetValue("EDID", null) as byte[];
                                        if (bObj != null)
                                        {
                                            //Get the 4 Vesa descriptor blocks
                                            string[] sDescriptor = new string[4];
                                            sDescriptor[0] = Encoding.Default.GetString(bObj, 0x36, 18);
                                            sDescriptor[1] = Encoding.Default.GetString(bObj, 0x48, 18);
                                            sDescriptor[2] = Encoding.Default.GetString(bObj, 0x5A, 18);
                                            sDescriptor[3] = Encoding.Default.GetString(bObj, 0x6C, 18);
                                            //Search the Keys
                                            foreach (string sDesc in sDescriptor)
                                            {
                                                if (sDesc.Contains(sSerFind))
                                                {
                                                    sSerial = sDesc.Substring(4).Replace("\0", "").Trim();
                                                }
                                                if (sDesc.Contains(sModFind))
                                                {
                                                    sModel = sDesc.Substring(4).Replace("\0", "").Trim();
                                                }
                                            }
                                        }
                                        if (!string.IsNullOrEmpty(sPNPID + sSerFind + sModel + sMonitorID))
                                        {
                                            yield return new DisplayDetails(sPNPID, sSerial, sModel, sMonitorID);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
