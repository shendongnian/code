    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    private const Int32 standardBufferSize = 0x10000; //64k
    private static Func<long, byte[]> createBuffer = x => (byte[])Array.CreateInstance(typeof(byte), x);
    /// <summary>
    /// Reads a <code>System.IO.Stream</code> to it's end using indicated buffer size.
    /// </summary>
    /// <param name="st"><code>System.IO.Stream</code></param>
    /// <param name="bufferSize">Buffer size in bytes</param>
    /// <returns><code>System.byte[]</code></returns>
    /// <seealso cref="readFullStream(Stream)"/>
    public static byte[] readFullStream(Stream st, Int32 bufferSize)
    {
        var _locked = false;
        Monitor.Enter(_lock, ref _locked);
        if (bufferSize <= 0) { bufferSize = standardBufferSize; }
        try
        {
            var size = 0;
            var continueRead = true;
            var buffer = createBuffer(bufferSize);
            using (var ms = new MemoryStream())
            {
                while (continueRead)
                {
                    size = st.Read(buffer, 0, buffer.Length);
                    if (size > 0)
                    {
                        ms.Write(buffer, 0, size);
                    }
                    else
                    {
                        continueRead = false;
                    }
                }
                return ms.ToArray();
            }
        }
        finally
        {
            if (_locked) Monitor.Exit(_lock);
        }
    }
