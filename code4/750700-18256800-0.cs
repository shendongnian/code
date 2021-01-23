        /// <summary>
        /// Tries to set the stream to position 0 if required.
        /// </summary>
        /// <returns>
        /// False if the stream is not at position 0 and does not support seek operations.
        /// </returns>
        public static bool TrySetPositionZero(this Stream stream)
        {
            if (stream.Position > 0)
            {
                if (stream.CanSeek)
                {
                    stream.Position = 0;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
