       listViewCookies.Columns.Add("TYPED URL", 300);
       listViewCookies.Columns.Add("TIME", 400);
            ListViewItem item = new ListViewItem();
            using (RegistryKey rk = Registry.Users.OpenSubKey(strSID + @"\Software\Microsoft\Internet Explorer\TypedURLs"))
            {
                try
                {
                    foreach (string u in rk.GetValueNames())
                    {
                        item.Text = rk.GetValue(u).ToString();
                    }
                }
                catch { }
            }
            using (RegistryKey rk = Registry.Users.OpenSubKey(strSID + @"\Software\Microsoft\Internet Explorer\TypedURLsTime"))
            {
                try
                {
                    foreach (string u in rk.GetValueNames())
                    {
                        object val = rk.GetValue(u);
                        DateTime output = DateTime.MinValue;
                        if (val is byte[] && ((byte[])val).Length == 8)
                        {
                            byte[] bytes = (byte[])val;
                            System.Runtime.InteropServices.ComTypes.FILETIME ft = new System.Runtime.InteropServices.ComTypes.FILETIME();
                            int valLow = bytes[0] + 256 * (bytes[1] + 256 * (bytes[2] + 256 * bytes[3]));
                            int valTwo = bytes[4] + 256 * (bytes[5] + 256 * (bytes[6] + 256 * bytes[7]));
                            ft.dwLowDateTime = valLow;
                            ft.dwHighDateTime = valTwo;
                            DateTime UTC = DateTime.FromFileTimeUtc((((long)ft.dwHighDateTime) << 32) + ft.dwLowDateTime);
                            TimeZoneInfo lcl = TimeZoneInfo.Local;
                            TimeZoneInfo utc = TimeZoneInfo.Utc;
                            output = TimeZoneInfo.ConvertTime(UTC, utc, lcl);
                            item.SubItems.Add(output.ToString());
                        }
                    }
                }
                catch { }
            }
            listViewCookies.Items.Add(item);
        }
