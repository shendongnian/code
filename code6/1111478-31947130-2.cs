    /// <summary>
    /// Custom XmlWriter.
    /// Wraps up another XmlWriter to intercept string writes within
    /// elements and writes them as CDATA instead.
    /// </summary>
    public class XmlCDataWriter : XmlTextWriter
    {
        public override void WriteString(string text)
        {
            if (WriteState == WriteState.Element)
            {
                WriteCData(text);
            }
            else
            {
                base.WriteString(text);
            }
        }
        /// <summary>
        /// Creates an instance of the XmlTextWriter class using the specified <see cref="T:System.IO.TextWriter"/>.
        /// </summary>
        /// <param name="w">The TextWriter to write to. It is assumed that the TextWriter is already set to the correct encoding. </param>
        public XmlCDataWriter( [NotNull] TextWriter w ) : base( w )
        {
        }
    }
