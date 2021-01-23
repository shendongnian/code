/// <summary>
/// Convert string to byte stream.
/// <para>
/// Slower than <see cref="Encoding.GetBytes()"/>, but saves memory for a large string.
/// </para>
/// </summary>
public class StringReaderStream : Stream
{
    private string input;
    private readonly Encoding encoding;
    private int maxBytesPerChar;
    private int inputLength;
    private int inputPosition;
    private readonly long length;
    private long position;
    public StringReaderStream(string input)
        : this(input, Encoding.UTF8)
    { }
    public StringReaderStream(string input, Encoding encoding)
    {
        this.encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        this.input = input;
        inputLength = input == null ? 0 : input.Length;
        if (!string.IsNullOrEmpty(input))
            length = encoding.GetByteCount(input);
        maxBytesPerChar = encoding.GetMaxByteCount(1);
    }
    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => false;
    public override long Length => length;
    public override long Position
    {
        get => position;
        set => throw new NotImplementedException();
    }
    public override void Flush()
    {
        throw new NotImplementedException();
    }
    public override int Read(byte[] buffer, int offset, int count)
    {
        if (inputPosition >= inputLength)
            return 0;
        if (count < maxBytesPerChar)
            throw new ArgumentException("count has to be greater or equal to max encoding byte count per char");
        int charCount = Math.Min(inputLength - inputPosition, count / maxBytesPerChar);
        int byteCount = encoding.GetBytes(input, inputPosition, charCount, buffer, offset);
        inputPosition += charCount;
        position += byteCount;
        return byteCount;
    }
    public override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotImplementedException();
    }
    public override void SetLength(long value)
    {
        throw new NotImplementedException();
    }
    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new NotImplementedException();
    }
}
