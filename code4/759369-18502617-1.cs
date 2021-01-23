private static byte[] RawBytesFromString(string input)
{
  var ret = new List&lt;Byte&gt;();
  foreach (char x in input)
  {
    var c = (byte)((ulong)x &amp; 0xFF);
    ret.Add(c);
  }
  return ret.ToArray();
}
