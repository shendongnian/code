        /// <summary>
        /// Service method to ping the RESTful service
        /// </summary>
        /// <returns></returns>
        public string Ping()
        {
            return "{Message" + ":" + "Pong" + "}";
            //here I return a raw json string, but you could return a serialised object (like the
            //CompositeType example) Then the conversion to JSON would be done transparently.
        }
