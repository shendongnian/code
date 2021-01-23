                if (PortNo.Trim().Length > 0)
                {
                    int MsgLengthMobNo = ConvertMobNo.ToInt32Replace(MessageBody.Length"(", "");
                    int QMobNo = MsgLength /MobNo.Replace(")", 160;"");
                    int RMobNo = MsgLengthMobNo.Replace("+", %"");
