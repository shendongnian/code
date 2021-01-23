    public static string getKey(string from = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", string valueName = "DigitalProductId")
    {
                RegistryKey hive = null;
                RegistryKey key = null;
                try
                {
                    var result = string.Empty;
                    hive = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Environment.MachineName);
                    key = hive.OpenSubKey(from, false);
                    var k = RegistryValueKind.Unknown;
                    try { k = key.GetValueKind(valueName); }
                    catch (Exception) { }
    
                    if (k == RegistryValueKind.Unknown)
                    {
                        key.Close();
                        hive.Close();
                        hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                        key = hive.OpenSubKey(from, false);
                        try { k = key.GetValueKind(valueName); }
                        catch (Exception) { }
                    }
    
                    if (k == RegistryValueKind.Binary)
                    {
                        var pivot = 0;
                        var bytes = (byte[])key.GetValue(valueName);
                        var ints = new int[16];
                        for (var i = 52; i < 67; ++i) ints[i - 52] = bytes[i];
                        for (var i = 0; i < 25; ++i)
                        {
                            pivot = 0;
                            for (var j = 14; j >= 0; --j)
                            {
                                pivot <<= 8;
                                pivot ^= ints[j];
                                ints[j] = ((int)Math.Truncate(pivot / 24.0));
                                pivot %= 24;
                            }
                            result = possible_chars[pivot] + result;
                            if ((i % 5 == 4) && (i != 24))
                            {
                                result = "-" + result;
                            }
                        }
                    }
                    return result;
                }
                catch (Exception) { return null; }
                finally
                {
                     key?.Close();
                     hive?.Close();
                }
    }
    private static readonly string possible_chars = "BCDFGHJKMPQRTVWXY2346789";
