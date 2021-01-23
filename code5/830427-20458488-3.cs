    internal class Program
    {
        public static void Main()
        {
            Stereo[] stereos = FunctionThatCreatesTheArray();
            using (var writeStream = File.OpenWrite(@"C:\Example\MultiChannelSong.bin"))
            {
                Stereo.Serialize(stereos, writeStream);
            }
            Stereo[] newStereos;
            using (var readStream = File.OpenRead(@"C:\Example\MultiChannelSong.bin"))
            {
               newStereos = Stereo.Deseralize(readStream);
            }
        }
    }
    public class Stereo
    {
        public int Samples;
        public float[] L, R;
        public Stereo(int N)
        {
            Samples = N;
            L = new float[N];
            R = new float[N];
        }
        public static void Serialize(Stereo[] stereos, Stream destination)
        {
            using (BinaryWriter writer = new BinaryWriter(destination, Encoding.Default, true))
            {
                //Write the size of the array to the file
                writer.Write(stereos.LongLength);
                foreach (Stereo stereo in stereos)
                {
                    //Write the number of samples there are
                    writer.Write(stereo.Samples);
                    //Write out the L channel
                    foreach (var l in stereo.L)
                    {
                        writer.Write(l);
                    }
                    //Write out the R channel
                    foreach (var r in stereo.R)
                    {
                        writer.Write(r);
                    }
                }
            }
        }
        public static Stereo[] Deseralize(Stream source)
        {
            using (BinaryReader reader = new BinaryReader(source, Encoding.Default, true))
            {
                //Read in the number of records
                var records = reader.ReadInt64();
                Stereo[] stereos = new Stereo[records];
                for (long i = 0; i < records; i++)
                {
                    //Read in the number of samples
                    var samples = reader.ReadInt32();
                    var stereo = new Stereo(samples);
                    //Read in the L channel
                    for (int j = 0; j < samples; j++)
                    {
                        stereo.L[j] = reader.ReadSingle();
                    }
                    //Read in the R channel
                    for (int j = 0; j < samples; j++)
                    {
                        stereo.R[j] = reader.ReadSingle();
                    }
                    //Set the sterieo object we created in to the array.
                    stereos[i] = stereo;
                }
                return stereos;
            }
        }
    }
