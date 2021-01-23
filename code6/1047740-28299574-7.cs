    ﻿using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    
    namespace Rubberduck.Config
    {
        [ComVisible(false)]
        public interface IConfigurationService
        {
            Configuration GetDefaultConfiguration();
            ToDoMarker[] GetDefaultTodoMarkers();
            Configuration LoadConfiguration();
            void SaveConfiguration<T>(T toSerialize);
        }
    }
