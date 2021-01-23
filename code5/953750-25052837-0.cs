    using System;
    using SFML.Audio;
    using NLayer;
    using System.Threading;
    
    namespace AudioCuesheetEditor.AudioBackend.SFML
    {
        /// <summary>
        /// Class for mp3 decoded audio files to use in SFML as Soundstream, since SFML doesn't support mp3 decoding (for legal reasons).
        /// </summary>
        public class Mp3StreamSFML : SoundStream
        {
            private static readonly Logfile log = Logfile.getLogfile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            private MpegFile mp3file;
            private Mutex mutex;
    
            /// <summary>
            /// Initializes a new instance of the <see cref="AudioCuesheetEditor.AudioBackend.SFML.Mp3StreamSFML"/> class.
            /// </summary>
            /// <param name="_filename">Full path to the file</param>
            public Mp3StreamSFML(String _filename)
            {
                log.debug("Constructor called with " + _filename);
                this.mp3file = new MpegFile(_filename);
                this.Initialize((uint)this.mp3file.Channels, (uint)this.mp3file.SampleRate);
                this.mutex = new Mutex();
            }
    
            public TimeSpan Duration
            {
                get
                {
                    log.debug("Duration = " + this.mp3file.Duration);
                    return this.mp3file.Duration;
                }
            }
    
            #region implemented abstract members of SoundStream
    
            protected override bool OnGetData(out short[] samples)
            {
                log.debug("OnGetData called");
                this.mutex.WaitOne();
                //Buffer data for about 1 second
                float[] normalizedaudiodata = new float[48000];
                int readSamples = this.mp3file.ReadSamples(normalizedaudiodata, 0, normalizedaudiodata.Length);
                short[] pcmaudiodata;
                if (readSamples > 0)
                {
                    pcmaudiodata = new short[readSamples]; // converted data
                    for (int i = 0; i < readSamples; i++)
                    {
                        // clip the data
                        if (normalizedaudiodata[i] > 1.0f)
                        {
                            normalizedaudiodata[i] = 1.0f;
                        }
                        else
                        {
                            if (normalizedaudiodata[i] < -1.0f)
                            {
                                normalizedaudiodata[i] = -1.0f;
                            }
                        }
                        // convert to pcm data
                        pcmaudiodata[i] = (short)(normalizedaudiodata[i] * short.MaxValue);
                    }
                    samples = pcmaudiodata;
                    this.mutex.ReleaseMutex();
                    return true;
                }
                else
                {
                    samples = null;
                    this.mutex.ReleaseMutex();
                    return false;
                }
            }
    
            protected override void OnSeek(TimeSpan timeOffset)
            {
                log.debug("OnSeek called with " + timeOffset);
                this.mutex.WaitOne();
                if ((timeOffset <= this.mp3file.Duration) && (timeOffset >= TimeSpan.Zero))
                {
                    this.mp3file.Time = timeOffset;
                }
                this.mutex.ReleaseMutex();
            }
    
            #endregion
        }
    }
