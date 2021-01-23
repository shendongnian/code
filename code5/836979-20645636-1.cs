    while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
    {
        byte[] newbytes = new byte[bytesRead];
        for(int i = 0; i < newbytes.Length; i++)
        {
            newbytes[i] = (byte)lst[buffer[i]]))
        }
        AppendAllBytes(textBox1.Text + ".ENC", newbytes);
    }
