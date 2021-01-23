    using CSCore;
    using CSCore.Codecs;
    using CSCore.SoundOut;
    using CSCore.Streams;
    using System;
    using System.Threading;
    
    ...
    
    private static void Main(string[] args)
    {
        const string filename = @"C:\Temp\test.mp3";
        EventWaitHandle waitHandle = new AutoResetEvent(false);
    
        try
        {
            //create a source which provides audio data
            using(var source = CodecFactory.Instance.GetCodec(filename))
            {
                //create the equalizer.
                //You can create a custom eq with any bands you want, or you can just use the default 10 band eq.
                Equalizer equalizer = Equalizer.Create10BandEqualizer(source);
    
                //create a soundout to play the source
                ISoundOut soundOut;
                if(WasapiOut.IsSupportedOnCurrentPlatform)
                {
                    soundOut = new WasapiOut();
                }
                else
                {
                    soundOut = new DirectSoundOut();
                }
    
                soundOut.Stopped += (s, e) => waitHandle.Set();
    
                IWaveSource finalSource = equalizer.ToWaveSource(16); //since the equalizer is a samplesource, you have to convert it to a raw wavesource
                soundOut.Initialize(finalSource); //initialize the soundOut with the previously created finalSource
                soundOut.Play();
    
                /*
                 * You can change the filter configuration of the equalizer at any time.
                 */
                equalizer.SampleFilters[0].SetGain(20); //eq set the gain of the first filter to 20dB (if needed, you can set the gain value for each channel of the source individually)
    
                //wait until the playback finished
                //of course that is optional
                waitHandle.WaitOne();
    
                //remember to dispose and the soundout and the source
                soundOut.Dispose();
            }
        }
        catch(NotSupportedException ex)
        {
            Console.WriteLine("Fileformat not supported: " + ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Unexpected exception: " + ex.Message);
        }
    }
