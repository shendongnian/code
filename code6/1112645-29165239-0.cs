     if (key != null)
                {
                    int j = 0;
                    string[] subKeys = key.GetSubKeyNames();
                    for (int i = 0; i < subKeys.Length; i++)
                    {
                        if (j < _browserList.Length)
                        {
                            if (Array.IndexOf(subKeys, _browserList[j]) != -1)
                            {
                                RegistryKey openSubKey = Registry.CurrentUser.OpenSubKey(AppPath);
                                if (openSubKey != null)
                                {
                                    string pathds = Path.Combine(openSubKey.ToString(), _browserList[j]);
                                    string value = SelectedBrowser(_browserList[j], pathds);
                                    keyvalDictionary.Add(_browserList[j], value);
                                    j++;
                                }
                            }
                        }
                        else
                            break;
                    }
                }
