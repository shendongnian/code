    // host looks like "127.0.0.1:8080"
    public static void EnableVPNProxy(string host)
    {
        RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Connections", true);
        foreach (var name in RegKey.GetValueNames())
        {
            try
            {
                byte[] server = Encoding.ASCII.GetBytes(host);
                byte[] current = (byte[])RegKey.GetValue(name);
                byte[] data = new byte[100];
                data[0] = current[0];
                data[1] = data[2] = data[3] = data[4] = data[5] = data[6] = data[7] = 0;
                data[8] = 3;
                data[9] = data[10] = data[11] = 0;
                data[12] = Convert.ToByte(server.Length);
                data[13] = data[14] = data[15] = 0;
                int i = 16;
                foreach (var b in server)
                {
                    data[i] = b;
                    i++;
                }
                for (var x = 0; x < 40; x++)
                {
                    data[i] = 0;
                    i++;
                }
               RegKey.SetValue(name, data);
            }
            catch (Exception ex) { }
        }
    }
