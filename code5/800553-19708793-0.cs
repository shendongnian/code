    private unsafe Bitmap ApplyAlgoritmPointer()
        {
            _alg._Erode(1);      //EmguCV Image.Erode
            _alg._Dilate(3);
            Bitmap b = _alg.Bitmap;
            BitmapData bData = b.LockBits(new Rectangle(0, 0, _alg.Width, _alg.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();
            for (int i = 1; i < bData.Height - 1; i++)
            {
                for (int j = 1; j < bData.Width - 1; j++)
                {
                    byte* dataCurrent = scan0 + i * bData.Stride + j;
                    //White pixels only
                    if (dataCurrent[0] == 255)
                    {
                        byte* dataLeft = scan0 + i * bData.Stride + (j - 1);
                        byte* dataTopLeft = scan0 + (i - 1) * bData.Stride + (j - 1);
                        byte* dataTop = scan0 + (i - 1) * bData.Stride + j;
                        byte* dataTopRight = scan0 + (i - 1) * bData.Stride + (j + 1);
                        //New label
                        if (dataLeft[0] == 0 && dataTopRight[0] == 0 && dataTopLeft[0] == 0 && dataTop[0] == 0)
                        {
                            dataCurrent[0] = _color;
                            _pixels.Add(new pixel(dataCurrent, _color));
                            _color++;
                        }
                        else
                        {
                            byte*[] array = new byte*[4] { dataLeft, dataTopLeft, dataTop, dataTopRight };
                            byte* max = array.MaxP();
                            byte* min = array.MinP();
                            if (max != min)   //Differend colors
                            {
                                dataCurrent[0] = min[0];                                 //menim obsah adresy
                                if (!_fromToD.ContainsKey(max[0]))
                                {
                                    if (max[0] == 255) continue;
                                    _fromToD.Add(max[0], new List<byte>() { min[0] });
                                }
                                else
                                {
                                    if (!_fromToD[max[0]].Contains(min[0]))
                                    {
                                        _fromToD[max[0]].Add(min[0]);
                                    }
                                }
                                _pixels.Add(new pixel(dataCurrent, min[0]));
                            }
                            else if (max == min)   //Same color
                            {
                                dataCurrent[0] = min[0];
                                _pixels.Add(new pixel(dataCurrent, min[0]));
                            }
                        }
                    
                    }
                }
            }
            //Second Pass
            NewList();
            for (int k = 0; k < _pixels.Count; k++)
            {
                for (int l = 0; l < _fromTo.Count; l++)
                {
                    if (_pixels[k].color == _fromTo[l].from)
                    {
                        _pixels[k].pix[0] = _fromTo[l].to;
                    }
                    else continue;
                }
            }
            b.UnlockBits(bData);
            return b;
        }
