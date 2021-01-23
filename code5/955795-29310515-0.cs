    /// <summary>
            /// Process a string to decode Unicode (Hangul) value to make Outlook EntryID. Pairs of hex digits make unicode chars
            /// </summary>
            /// <param name="sIn"></param>
            /// <returns></returns>
            public static string ProcessHangul(string sIn)
            {
                string sOut = "";
                try
                {
                    for (int i = 0; i < sIn.Length; i++)
                    {
                        int iCode = sIn[i];
                        string hexCode = iCode.ToString("X");
                        //System.Diagnostics.Debug.Print(i + " " + hexCode);
                        sOut += hexCode.Substring(2, 2);
                    }
                }
                catch (Exception Ex)
                {
                    Common.LogError("ProcessHangul error", Ex);
                }
                return sOut;
            }
