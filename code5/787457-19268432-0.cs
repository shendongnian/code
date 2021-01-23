    while (wave.Position != length)
                {                
                    UInt16 read = wave.Read(mainBuffer, 0, mainBuffer.Length);
                    double[] segment = new double[read / 8];
                    for (UInt16 i = 0; i < segment.Length; i++)
                    {
                        segment[i] =BitConverter.ToSingle(mainBuffer, i * 8);
                    }               
                    ent.Add(obj.entropy(segment));                
                }
