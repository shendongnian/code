    string sHangul = "";
                        if (sURL.IndexOf("/at=") == -1) // if no attachment
                        { sHangul = Path.GetFileName(sURL); }
                        else
                        {
                            sHangul = Path.GetFileName(Path.GetDirectoryName(sURL));
                        }
                        sEntryID = Common.ProcessHangul(sHangul);
