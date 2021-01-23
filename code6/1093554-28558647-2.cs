        public static string ReadTextResourceFromAssembly(string name)
        {
            using ( var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream( name ) )
            {
                return new StreamReader( stream ).ReadToEnd();
            }
        }
