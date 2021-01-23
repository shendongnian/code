    byte[] bajti = HexToBytes(hex1.Text);
                        char c = 'a';
                        if (bajti.Length == 1)
                        {
                            c = (char)bajti[0];
                        }
                        else if (bajti.Length == 2)
                        {
                            c = (char)((bajti[0] << 8) + bajti[1]);
                        }
                        znak1.Text = c.ToString();
