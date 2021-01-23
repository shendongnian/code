    namespace FMOD
    {
        public partial class System
        {
            [DllImport(VERSION.dll)]
            private static extern RESULT FMOD_System_CreateSound(IntPtr system, IntPtr name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
            [DllImport(VERSION.dll)]
            private static extern RESULT FMOD_System_CreateStream(IntPtr system, IntPtr name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
            public RESULT createSound(IntPtr data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
            {
                RESULT result = RESULT.OK;
                IntPtr soundraw = new IntPtr();
                Sound soundnew = null;
                try
                {
                    result = FMOD_System_CreateSound(systemraw, data, mode, ref exinfo, ref soundraw);
                }
                catch
                {
                    result = RESULT.ERR_INVALID_PARAM;
                }
                if (result != RESULT.OK)
                {
                    return result;
                }
                if (sound == null)
                {
                    soundnew = new Sound();
                    soundnew.setRaw(soundraw);
                    sound = soundnew;
                }
                else
                {
                    sound.setRaw(soundraw);
                }
                return result;
            }
            public RESULT createStream(IntPtr data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
            {
                RESULT result = RESULT.OK;
                IntPtr soundraw = new IntPtr();
                Sound soundnew = null;
                try
                {
                    result = FMOD_System_CreateStream(systemraw, data, mode, ref exinfo, ref soundraw);
                }
                catch
                {
                    result = RESULT.ERR_INVALID_PARAM;
                }
                if (result != RESULT.OK)
                {
                    return result;
                }
                if (sound == null)
                {
                    soundnew = new Sound();
                    soundnew.setRaw(soundraw);
                    sound = soundnew;
                }
                else
                {
                    sound.setRaw(soundraw);
                }
                return result;
            }
        }
    }
