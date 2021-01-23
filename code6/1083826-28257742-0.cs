       public static class AzureMobileService
        {
            /// <summary>
            /// Initializes static members of the <see cref="AzureMobileService"/> class. 
            /// </summary>
            static AzureMobileService()
            {
                Instance = new MobileServiceClient("http://<your url>.azure-mobile.net/", "< you key>")
                {
                    SerializerSettings = new MobileServiceJsonSerializerSettings()
                    {
                        CamelCasePropertyNames = true
                    }
                };
            }
            /// <summary>
            /// Gets or sets the Instance.
            /// </summary>
            /// <value>
            /// The customers service.
            /// </value>
            public static MobileServiceClient Instance { get; set; }
        }
