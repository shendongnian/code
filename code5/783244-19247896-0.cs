            NAudio.Wave.WaveChannel32 wave = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(open.FileName));
            WaveFileReader wavFile = new WaveFileReader(open.FileName);
            int sampleRate = wave.WaveFormat.SampleRate;
            byte[] mainBuffer = new byte[wave.WaveFormat.AverageBytesPerSecond / 5];
            #region Constraints
            int window_ms = 200;
            int window;
            int fs = sampleRate;
            window = window_ms * fs / 1000;
            #endregion
            int read;
            int length = (int)wave.Length;
            List<double> listOfEnergies = new List<double>();
            List<MWArray> ent = new List<MWArray>();
            MWNumericArray arr1 = null;
            EntropyCalculation obj = new EntropyCalculation();
            if (wave.Length % mainBuffer.Length != 0)
            {
                int value = (int)(wave.Length / mainBuffer.Length);
                length = mainBuffer.Length * value;
            }
            while (wave.Position != length)
            {
                List<double> segment = new List<double>();
                List<double> listOfSquaredSegment = new List<double>();
                read = wave.Read(mainBuffer, 0, mainBuffer.Length);
                for (int i = 0; i < read / 8; i++)
                {
                    segment.Add((BitConverter.ToSingle(mainBuffer, i * 8)));
                    double segmentSquare = segment[i] * segment[i];
                    listOfSquaredSegment.Add(segmentSquare);
                    //arr1 = segment.ToArray();
                }
                arr1 = segment.ToArray();
                double energy = Math.Sqrt(listOfSquaredSegment.Sum());
                listOfEnergies.Add(energy);
                MWArray result = obj.entropy(arr1);
                ent.Add(result);
                arr1 = null;
            }
