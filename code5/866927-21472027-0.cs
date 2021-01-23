            protected override void WndProc(ref Message m)
            {
                try
                {
                    if (m.Msg == WM_DEVICECHANGE)
                    {
                        DEV_BROADCAST_VOLUME vol = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
                        if ((m.WParam.ToInt32() == DBT_DEVICEARRIVAL) && (vol.dbcv_devicetype == DBT_DEVTYPVOLUME))
                        {
                            usb_drive = DriveMaskToLetter(vol.dbcv_unitmask).ToString();
                           
                            if (usb_drive.Replace(" ", "").Length > 0)
                            {
                                                
                                // USB Inserted                                  
                            }
                        }
                        if ((m.WParam.ToInt32() == DBT_DEVICEREMOVALCOMPLETE) && (vol.dbcv_devicetype == DBT_DEVTYPVOLUME))
                        {
                            //USB Removed
                        }
                    }
                    base.WndProc(ref m);
                }
                catch
                {
    
                }
            }
    
