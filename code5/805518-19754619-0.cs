        class CardReader : IDisposable
        {
            IntPtr _pSnr = Marshal.AllocHGlobal(1024);
            private Thread _t;
            private Action<string> _callback;
            private volatile bool _stop;
            public void ReadCard()
            {
                short icdev = 0x0000;
                int status;
                byte type = (byte)'A';//mifare one type is A 卡询卡方式为A
                byte mode = 0x26;  // Request the card which is not halted.
                ushort TagType = 0;
                byte bcnt = 0x04;//mifare 卡都用4, hold on 4
                IntPtr pSnr;
                byte len = 255;
                sbyte size = 0;
                for (int i = 0; i < 2; i++) {
                    status = rf_request(icdev, mode, ref TagType);//搜寻没有休眠的卡，request card  
                    if (status != 0)
                        continue;
                    status = rf_anticoll(icdev, bcnt, pSnr, ref len);//防冲突得到返回卡的序列号, anticol--get the card sn
                    if (status != 0)
                        continue;
                    status = rf_select(icdev, pSnr, len, ref size);//锁定一张ISO14443-3 TYPE_A 卡, select one card
                    if (status != 0)
                        continue;
                    byte[] szBytes = new byte[len];
                    for (int j = 0; j < len; j++) {
                        szBytes[j] = Marshal.ReadByte(pSnr, j);
                    }
                    String m_cardNo = String.Empty;
                    for (int q = 0; q < len; q++) {
                        m_cardNo += byteHEX(szBytes[q]);
                    }
                    _callback(m_cardNo);
                    break;
                }
            }
            public void Work()
            {
                while (!_stop)
                {
                    ReadCard();
                    Thread.Sleep(1000);
                }
            }
            public void Start(Action<string> cardRead)
            {
                if (_t != null)
                    return;
                _stop = false;
                _callback = cardRead;
                _t = new Thread(Work);
                _t.Start();
            }
            public void Stop()
            {
                if (_t != null)
                {
                    _stop = true;
                    _t.Join();
                    _t = null;
                }
            }
            public void Dispose()
            {
                Marshal.FreeHGlobal(_pSnr);                
            }
        }
