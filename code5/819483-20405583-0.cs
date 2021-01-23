        public void FindPath()
        {
            foreach (ManagementObject entity in new ManagementObjectSearcher("select * from Win32_USBHub Where DeviceID Like '%VID_XXXX&PID_XXXX%'").Get())
            {
                Entity = entity["DeviceID"].ToString();
                foreach (ManagementObject controller in entity.GetRelated("Win32_USBController"))
                {
                    foreach (ManagementObject obj in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_USBController.DeviceID='" + controller["PNPDeviceID"].ToString() + "'}").Get())
                    {
                        if(obj.ToString().Contains("DeviceID"))
                            USBobjects.Add(obj["DeviceID"].ToString());
                        
                    }
                }
            }
            int VidPidposition = USBobjects.IndexOf(Entity);
            for (int i = VidPidposition; i <= USBobjects.Count; i++ )
            {
                if (USBobjects[i].Contains("USBSTOR"))
                {
                    Secondentity = USBobjects[i];
                    break;
                }
                
            }
        }
