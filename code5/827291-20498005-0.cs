        public void detektieren_Click(object sender, RoutedEventArgs e)
        {
            for (i = 0; i < bitmap.Height; i++)
            {
                for (j = 0; j < bitmap.Width; j++)
                {
                    stride = bitmap.PixelWidth * (bitmap.Format.BitsPerPixel / 8);
                    data = new byte[stride * bitmap.PixelHeight];
                    bitmap.CopyPixels(data, stride, 0);
                    index = i * stride + 4 * j;
                    byte A = data[index + 3];
                    byte R = data[index + 2];
                    byte G = data[index + 1];
                    byte B = data[index];
                    // Create a writer and open the file:
                    StreamWriter Messdaten;
                    if (!File.Exists("C:/Users/.../Messdaten.csv"))
                    {
                        Messdaten = new StreamWriter("C:/Users/.../Messdaten.csv");
                    }
                    else
                    {
                        Messdaten = File.AppendText("C:/Users/.../Messdaten.csv");
                    }
                    // Write to the file:
                    Messdaten.WriteLine(index + ";" + A + ";" + R + ";" + G + ";" + B);
                    // Close the stream:
                    Messdaten.Close();
                    if (Convert.ToInt32(R) == 0 && Convert.ToInt32(G) == 0 && Convert.ToInt32(B) == 255)
                    {
                        // Create a writer and open the file:
                        StreamWriter Messdaten2;
                        if (!File.Exists("C:/Users/.../Messdaten2.csv"))
                        {
                           Messdaten2 = new StreamWriter("C:/Users/.../Messdaten2.csv");
                        }
                        else
                        {
                            Messdaten2 = File.AppendText("C:/Users/.../Messdaten2.csv");
                        }
                        // Write to the file:
                        Messdaten2.WriteLine(index + ";" + i + ";" + j);
                        // Close the stream:
                        Messdaten2.Close();
                    }
                }
            }
        }
