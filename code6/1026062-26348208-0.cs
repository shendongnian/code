    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace CoreAudioApi.Interfaces
    {
        [Guid("7FB7B48F-531D-44A2-BCB3-5AD5A134B3DC"),
         InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IAudioVolumeLevel : IPerChannelDbLevel { }
    }
