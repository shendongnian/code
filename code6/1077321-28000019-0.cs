    var bytes = (byte[]) key.GetValue("EDID");
    
    if (bytes == null) return;
    
    /* Read model number */
    var buffer = new byte[4];
    for (var i = 54; i < 109; i += 18)
    {
        var sb = new StringBuilder();
        
        Buffer.BlockCopy(bytes, i, buffer, 0, 4);
        
        Array.Reverse(buffer);
        
        if (BitConverter.ToInt32(buffer, 0).Equals(0xFF))
        {
            for (var j = i + 5; (bytes[j] != 10) && (j < i + 18); j++)
            {
                sb.Append((char) bytes[j]);
            }
            
            this.ModelNo = sb.ToString();
            sb.Clear();
        }
        
        if (BitConverter.ToInt32(buffer, 0).Equals(0xFC))
        {
            for (var j = i + 5; (bytes[j] != 10) && (j < i + 18); j++)
            {
                sb.Append((char)bytes[j]);
            }
            
            this.Model = sb.ToString();
            sb.Clear();
        }
    }
    
    if (string.IsNullOrEmpty(this.ModelNo)) this.ModelNo = string.Empty;
    
    if (string.IsNullOrEmpty(this.Model)) this.Model = string.Empty;
    
    /* Read serial number */
    
    buffer = new byte[4];
    Buffer.BlockCopy(bytes, 12, buffer, 0, 4);
    
    //this.SerialNo = BitConverter.ToString(buffer);
    
    this.SerialNo = string.Concat(buffer.Select(b => b.ToString("X2")));
    
    /* Read screen size */
    var x = (int) bytes[21];
    var y = (int) bytes[22];
    
    this.Size = Math.Round(Math.Sqrt(x * x + y * y) / 2.54).ToString();
