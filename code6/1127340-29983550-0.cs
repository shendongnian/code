        private void FillInComportComboBox()
        {
            Hashtable PortNames = new Hashtable();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            //string st = ComPortList.Text;
           
            ComPortList.Items.Clear();
            if (ports.Length == 0)
            {
                ComPortList.Items.Add("ERROR: No COM ports exist");
            }
            else
            {
                PortNames = BuildPortNameHash(ports);
                //foreach (string s in ports)
                foreach(String s in PortNames.Keys)
                {
                    //ComPortList.Items.Add(s + ":  " + (string)PortNames[s]);
                    ComPortList.Items.Add(PortNames[s] + ": " + s);
                }
            }
        }
        // Begins recursive registry enumeration
        // <param name="oPortsToMap">array of port names (i.e. COM1, COM2, etc)</param>
        // <returns>a hashtable mapping Friendly names to non-friendly port values</returns>
        Hashtable BuildPortNameHash(string[] oPortsToMap)
        {
            Hashtable oReturnTable = new Hashtable();
            MineRegistryForPortName("SYSTEM\\CurrentControlSet\\Enum", oReturnTable, oPortsToMap);
            return oReturnTable;
        }
        // Recursively enumerates registry subkeys starting with strStartKey looking for 
        // "Device Parameters" subkey. If key is present, friendly port name is extracted.
        // <param name="strStartKey">the start key from which to begin the enumeration</param>
        // <param name="oTargetMap">hashtable that will get populated with 
        // friendly-to-nonfriendly port names</param>
        // <param name="oPortNamesToMatch">array of port names (i.e. COM1, COM2, etc)</param>
        void MineRegistryForPortName(string strStartKey, Hashtable oTargetMap, string[] oPortNamesToMatch)
        {
            if (oTargetMap.Count >= oPortNamesToMatch.Length)
                return;
            RegistryKey oCurrentKey = Registry.LocalMachine;
            try
            {
                oCurrentKey = oCurrentKey.OpenSubKey(strStartKey);
                string[] oSubKeyNames = oCurrentKey.GetSubKeyNames();
                if (((IList<string>)oSubKeyNames).Contains("Device Parameters") && strStartKey != "SYSTEM\\CurrentControlSet\\Enum")
                {
                    object oPortNameValue = Registry.GetValue("HKEY_LOCAL_MACHINE\\" + strStartKey + "\\Device Parameters", "PortName", null);
                    if (oPortNameValue == null || ((IList<string>)oPortNamesToMatch).Contains(oPortNameValue.ToString()) == false)
                        return;
                    object oFriendlyName = Registry.GetValue("HKEY_LOCAL_MACHINE\\" + strStartKey, "FriendlyName", null);
                    string strFriendlyName = "N/A";
                    if (oFriendlyName != null)
                        strFriendlyName = oFriendlyName.ToString();
                    if (strFriendlyName.Contains(oPortNameValue.ToString()) == false)
                        strFriendlyName = string.Format("{0} ({1})", strFriendlyName, oPortNameValue);
                    oTargetMap[strFriendlyName] = oPortNameValue;
                    //oTargetMap[oPortNameValue] = strFriendlyName;
                }
                else
                {
                    foreach (string strSubKey in oSubKeyNames)
                        MineRegistryForPortName(strStartKey + "\\" + strSubKey, oTargetMap, oPortNamesToMatch);
                }
            }
            catch
            {
            }
        }
