      void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (writeToBuffer1)
            {
                numToRead1 = SerialPort.BytesToRead;
                mutex1.WaitOne();
                numRead1 = SerialPort.Read(buffer1, 0, numToRead1);
                mutex1.ReleaseMutex();
                writeToBuffer1 = false;
                PlotData(buffer1, numRead1);
            }
            else
            {
                numToRead2 = SerialPort.BytesToRead;
                mutex2.WaitOne();
                numRead2 = SerialPort.Read(buffer2, 0, numToRead2);
                mutex2.ReleaseMutex();
                writeToBuffer1 = true;
                PlotData(buffer2, numRead2);
            }
        }
