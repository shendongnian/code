    private void button1_Click(object sender, EventArgs e)
            {
                int size = -1;
                openFileDialog1.Title = "Open Prt File";
               
                openFileDialog1.InitialDirectory = @"C:\";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    string file = openFileDialog1.FileName;
                    label1.Text = file;
                    try
                    {
                        FileStream stream = File.OpenRead(@file);
                        byte[] NumberOfByteprLine = new byte[4];
                        byte[] NumberOfLineInImage = new byte[4];
    
    
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        stream.Close();
                        
                        int j = 19;
                        Int64 decValue;
                        decValue = buffer[j--] * 256 * 256 * 256;
                        decValue += buffer[j--] * 256 * 256;
                        decValue += buffer[j--] * 256;
                        decValue += buffer[j--];
                        Int32 ImageHeight = Convert.ToInt32(decValue);
    
                        j = 15;
                        decValue = buffer[j--] * 256 * 256 * 256;
                        decValue += buffer[j--] * 256 * 256;
                        decValue += buffer[j--] * 256;
                        decValue += buffer[j--];
                        Int32 NumberOfBytePerLine = Convert.ToInt32(decValue);
    
                        j = 23;
                        decValue = buffer[j--] * 256 * 256 * 256;
                        decValue += buffer[j--] * 256 * 256;
                        decValue += buffer[j--] * 256;
                        decValue += buffer[j--];
                        Int32 ImageWidth = Convert.ToInt32(decValue);
    
                        string hexXResValue = string.Empty, hexYResValue = string.Empty;
                        for (int i = 11; i > 3; i--)
                        {
                            if (i > 7)
                            {
                                hexYResValue = hexYResValue + Convert.ToInt64(buffer[i]).ToString("X");
                            }
                            else
                            {
                                hexXResValue = hexXResValue + Convert.ToInt64(buffer[i]).ToString("X");
                            }
                        }
    
                        //Int32 ImageWidth = int.Parse(hexWValue, System.Globalization.NumberStyles.HexNumber);
                        //Int32 ImageHeight = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
    
                        Int32 XResolution = int.Parse(hexXResValue, System.Globalization.NumberStyles.HexNumber);
                        Int32 YResolution = int.Parse(hexYResValue, System.Globalization.NumberStyles.HexNumber);
    
                        Int64 StartByte = 48;
    
                        int width = NumberOfBytePerLine, hieght = ImageHeight;
                        Bitmap bmp = new Bitmap(width, hieght);
                        int value = 0;
                        for(int i=0; i<ImageHeight;i++)
                        {
                         
                            for (Int32 k = 0; k < NumberOfBytePerLine; k++)
                            {
    
    
                                decValue = buffer[StartByte];
                                string hexValue = decValue.ToString("X");
                              
                                int Y = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
    
                                decValue = buffer[StartByte + NumberOfBytePerLine];
                                hexValue = decValue.ToString("X");
    
                                int M = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
    
                                decValue = buffer[StartByte + NumberOfBytePerLine*2];
                                hexValue = decValue.ToString("X");
    
                                int C = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
    
                                decValue = buffer[StartByte + NumberOfBytePerLine*3];
                                hexValue = decValue.ToString("X");
    
                                int K = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
    
                              
                                 RGB rgb = CMYKtoRGB((double)C / 100.0, (double)M / 100.0, (double)Y / 100.0, (double)K / 100.0);
    
                                StartByte++;
    
                                bmp.SetPixel(k, i, Color.FromArgb(rgb.Red, rgb.Green, rgb.Blue));
    
                              
                                value++;
                                                           
                            }
    
                            StartByte = StartByte + (NumberOfBytePerLine * 3);
    
                        }
    
    
                        pictureBox1.Image = bmp;
                        string Path = "C:\\Users\\Abhishek Singh\\Desktop\\PrtFile\\prtfiles\\imageFile.bmp";
    
                        bmp.Save(Path);
                        
    
                    }
                    catch { }
                }
            }
    
    
    
             /// <summary>
            /// Converts CMYK to RGB.
            /// </summary>
            /// <param name="c">Cyan value (must be between 0 and 1).</param>
            /// <param name="m">Magenta value (must be between 0 and 1).</param>
            /// <param name="y">Yellow value (must be between 0 and 1).</param>
            /// <param name="k">Black value (must be between 0 and 1).</param>
            public static RGB CMYKtoRGB(double c, double m, double y, double k)
            {
                int red = Convert.ToInt32((1.0 - c) * (1.0 - k) * 255.0);
                int green = Convert.ToInt32((1.0 - m) * (1.0 - k) * 255.0);
                int blue = Convert.ToInt32((1.0 - y) * (1.0 - k) * 255.0);
    
                return new RGB(red, green, blue);
            }
