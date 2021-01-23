         private void sendFrame(IplImage input) {
            try
            {
                // setup matrix
                Int32 matrix_id = BitConverter.ToInt32(Encoding.ASCII.GetBytes(JIT_MATRIX_PACKET_ID), 0);
                Int32 planecount = input.NumChannels;
                Int32 typeSize = input.Depth;
                Int32 type = JIT_MATRIX_TYPE_CHAR;
                Int32 width = input.Width;
                Int32 height = input.Height;
                m_matrixHeader.id = matrix_id;
                m_matrixHeader.size = 288;
                m_matrixHeader.planecount = planecount;
                m_matrixHeader.type = type;
                m_matrixHeader.dimcount = 2;
                Int32[] dim = new Int32[32];
                dim[0] = width;
                dim[1] = height;
                int i2 = 2;
                while (i2 < JIT_MATRIX_MAX_DIMCOUNT)
                {
                    dim[i2] = 1;
                    i2++;
                }
                Int32[] dimstride = new Int32[32];
                dimstride[0] = planecount;
                dimstride[1] = width * planecount;
                i2 = 2;
                while (i2 < JIT_MATRIX_MAX_DIMCOUNT)
                {
                    dimstride[i2] = 0;
                    i2++;
                }
                Int32 datasize = planecount * width * height;
                m_chunkHeader.id = BitConverter.ToInt32(Encoding.ASCII.GetBytes(JIT_MATRIX_PACKET_ID), 0);
                m_chunkHeader.size = sizeof(Int32) * (6 + 32 + 32) + sizeof(double); //should be 288 bytes
                byte[] chunkHeader = StructToBytes(m_chunkHeader, Endianness.LittleEndian);
                //Console.WriteLine(BitConverter.ToString(chunkHeader));
                byte[] matrixHeader = StructToBytes(m_matrixHeader, Endianness.BigEndian);
                //Console.WriteLine(BitConverter.ToString(matrixHeader));
                byte[] dim_send = new byte[4 * 32];
                byte[] dimstride_send = new byte[4 * 32];
                for (int i = 0; i < 32; i++)
                {
                    byte[] dimbytes = BitConverter.GetBytes(dim[i]);
                    Array.Reverse(dimbytes);
                    System.Buffer.BlockCopy(dimbytes, 0, dim_send, i * 4, dimbytes.Length);
                    byte[] dimstridebytes = BitConverter.GetBytes(dimstride[i]);
                    Array.Reverse(dimstridebytes);
                    System.Buffer.BlockCopy(dimstridebytes, 0, dimstride_send, i * 4, dimstridebytes.Length);
                }
                //Console.WriteLine(BitConverter.ToString(dim_send));
                //Console.WriteLine(BitConverter.ToString(dimstride_send));
                byte[] datasize_send = BitConverter.GetBytes(datasize);
                Array.Reverse(datasize_send);
                //Console.WriteLine(BitConverter.ToString(datasize_send));
                double time = 0; //todo: should be elapsed time, not 0
                byte[] time_send = BitConverter.GetBytes(time);
                Array.Reverse(time_send);
                //Console.WriteLine(BitConverter.ToString(time_send));
                int size = width * height * 4;//input.Height * input.Width * input.NumChannels * input.Depth / 4;
                byte[] managedArray = new byte[size];
                Marshal.Copy(input.ImageData, managedArray, 0, size);
                Array.Reverse(managedArray);
                byte[] output = new byte[chunkHeader.Length + matrixHeader.Length + dim_send.Length + dimstride_send.Length + datasize_send.Length + time_send.Length + managedArray.Length];
                // chunkheader
                System.Buffer.BlockCopy(chunkHeader, 0, output, 0, chunkHeader.Length);
                // matrixheader
                System.Buffer.BlockCopy(matrixHeader, 0, output, chunkHeader.Length, matrixHeader.Length);
                // dim
                System.Buffer.BlockCopy(dim_send, 0, output, chunkHeader.Length + matrixHeader.Length, dim_send.Length);
                // dimstride
                System.Buffer.BlockCopy(dimstride_send, 0, output, chunkHeader.Length + matrixHeader.Length + dim_send.Length, dimstride_send.Length);
                // datasize
                System.Buffer.BlockCopy(datasize_send, 0, output, chunkHeader.Length + matrixHeader.Length + dim_send.Length + dimstride_send.Length, datasize_send.Length);
                // time
                System.Buffer.BlockCopy(time_send, 0, output, chunkHeader.Length + matrixHeader.Length + dim_send.Length + dimstride_send.Length + datasize_send.Length, time_send.Length);
                // matrix array
                System.Buffer.BlockCopy(managedArray, 0, output, chunkHeader.Length + matrixHeader.Length + dim_send.Length + dimstride_send.Length + datasize_send.Length + time_send.Length, managedArray.Length);
                //Console.WriteLine(BitConverter.ToString(output));
                if (myClient.Connected)
                    myStream.Write(output, 0, output.Length);
            } catch ( Exception e )
            {
                Console.WriteLine("Exception: " + e.InnerException.Message);
            }
        }
