    using System;
    using CServer.API;
    
    namespace Whatever
    {
        // : is broadly equivalent to both implements and extends
        public class WhateverPlugin : Plugin
        {
            public WhateverPlugin() // implicitly calls base constructor
            {
                // This will execute after the Plugin constructor body
            }
        }
    }
