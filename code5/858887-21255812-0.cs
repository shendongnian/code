            /// <summary>
            /// Only applicable for serializable object
            /// Makes a copy from the object.
            /// Doesn't copy the reference memory, only data.
            /// </summary>
            /// <typeparam name="T">Type of the return object.</typeparam>
            /// <param name="item">Object to be copied.</param>
            /// <returns>Returns the copied object.</returns>
            public static T Clone<T>(this T item)
            {
                if (item != null)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream stream = new MemoryStream();
    
                    formatter.Serialize(stream, item);
                    stream.Seek(0, SeekOrigin.Begin);
    
                    T result = (T)formatter.Deserialize(stream);
    
                    stream.Close();
    
                    return result;
                }
                else
                    return default(T);
            }
