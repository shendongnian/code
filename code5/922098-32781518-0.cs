    [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section,
                     string key, string def, StringBuilder retVal,
                    int size, string filePath);
     /// <summary>
            /// read value from given section and key
            /// </summary>
            /// <param name="Section">string</param>
            /// <param name="Key">string</param>
            /// <returns>string</returns>
     public string IniReadValue(string Section, string Key)
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp,
                                                255, this.path);
                return temp.ToString();
    
            }
