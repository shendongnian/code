        /// <summary>
        /// This method clones all of the items and serializable properties of the current collection by 
        /// serializing the current object to memory, then deserializing it as a new object. This will 
        /// ensure that all references are cleaned up.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public T CreateSerializedCopy<T>(T oRecordToCopy)
        {
            // Exceptions are handled by the caller
            if (oRecordToCopy == null)
            {
                return default(T);
            }
            if (!oRecordToCopy.GetType().IsSerializable)
            {
                throw new ArgumentException(oRecordToCopy.GetType().ToString() + " is not serializable");
            }
            var oFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (var oStream = new MemoryStream())
            {
                oFormatter.Serialize(oStream, oRecordToCopy);
                oStream.Position = 0;
                return (T)oFormatter.Deserialize(oStream);
            }
        }
