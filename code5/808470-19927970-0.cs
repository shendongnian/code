    StringBuilder inputRequestBuilder = new StringBuilder();
    List<byte> bytes = new List<byte>();
    List<byte> last4bytes = new List<byte>();
    string request = null;
    using (var input = socket.InputStream.AsStreamForRead())
    {
        int b;
        while (true)
        {
            try
            {
                b = input.ReadByte();
            }
            catch(Exception e) {
                FileManager.WriteToDebug(e.ToString());
                break;
            }
            bytes.Add((byte)b);
            if (last4bytes.Count < 4)
            {
                last4bytes.Add((byte)b);
            }
            else
            {
                last4bytes.RemoveAt(0);
                last4bytes.Add((byte)b);
                if (last4bytes.ElementAt(0) == 13 && last4bytes.ElementAt(1) == 10
                    && last4bytes.ElementAt(2) == 13 && last4bytes.ElementAt(3) == 10)
                {
                    //after \r\n\r\n there is the content
    				byte[] byteArray = bytes.ToArray();
                    request = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                    inputRequestBuilder.Append(request);
                    string contentLength = getValueFromHeader("Content-Length", request);
                    if (!contentLength.Equals(""))
                    {
                        int length = Convert.ToInt32(contentLength);
                        if (length > 0)
                        {
                            byteArray = new byte[length];
                            input.Read(byteArray, 0, length);
                            var dataString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                            inputRequestBuilder.Append(dataString);
                        }
                    }
                    break;
                }
            }
        }
    }
    request = inputRequestBuilder.ToString();
