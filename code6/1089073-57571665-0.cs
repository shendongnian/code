    #region Input0ByIndexBuffer
    //inherit via BufferWrapper 
    public class Input0ByIndexBuffer : Input0Buffer
    {
        public Input0ByIndexBuffer(PipelineBuffer Buffer, int[] BufferColumnIndexes, OutputNameMap OutputMap) : base(Buffer, BufferColumnIndexes, OutputMap)
        {
        }
        new public bool IsNull(int columnIndex)
        {
            return base.IsNull(columnIndex);
        }
        new public void SetNull(int columnIndex)
        {
            base.SetNull(columnIndex);
        }
        public BufferColumn GetColumnInfo(int columnIndex)
        {
            return Buffer.GetColumnInfo(BufferColumnIndexes[columnIndex]);
        }
        //expose the Buffer.Get methods using the columnindex, this enables iterations over index instead of columns names
        public sbyte GetSByte(int columnIndex)
        {
            return Buffer.GetSByte(BufferColumnIndexes[columnIndex]);
        }
        public byte GetByte(int columnIndex)
        {
            return Buffer.GetByte(BufferColumnIndexes[columnIndex]);
        }
        public bool GetBoolean(int columnIndex)
        {
            return Buffer.GetBoolean(BufferColumnIndexes[columnIndex]);
        }
        public short GetInt16(int columnIndex)
        {
            return Buffer.GetInt16(BufferColumnIndexes[columnIndex]);
        }
        public int GetInt32(int columnIndex)
        {
            return Buffer.GetInt32(BufferColumnIndexes[columnIndex]);
        }
        public uint GetUInt32(int columnIndex)
        {
            return Buffer.GetUInt32(BufferColumnIndexes[columnIndex]);
        }
        public long GetInt64(int columnIndex)
        {
            return Buffer.GetInt64(BufferColumnIndexes[columnIndex]);
        }
        public ulong GetUInt64(int columnIndex)
        {
            return Buffer.GetUInt64(BufferColumnIndexes[columnIndex]);
        }
        public decimal GetDecimal(int columnIndex)
        {
            return Buffer.GetDecimal(BufferColumnIndexes[columnIndex]);
        }
        public float GetSingle(int columnIndex)
        {
            return Buffer.GetSingle(BufferColumnIndexes[columnIndex]);
        }
        public double GetDouble(int columnIndex)
        {
            return Buffer.GetDouble(BufferColumnIndexes[columnIndex]);
        }
        public DateTime GetDateTime(int columnIndex)
        {
            return Buffer.GetDateTime(BufferColumnIndexes[columnIndex]);
        }
        public DateTime GetDate(int columnIndex)
        {
            return Buffer.GetDate(BufferColumnIndexes[columnIndex]);
        }
        public byte[] GetBytes(int columnIndex)
        {
            return Buffer.GetBytes(BufferColumnIndexes[columnIndex]);
        }
        public DateTimeOffset GetDateTimeOffset(int columnIndex)
        {
            return Buffer.GetDateTimeOffset(BufferColumnIndexes[columnIndex]);
        }
        public Guid GetGuid(int columnIndex)
        {
            return Buffer.GetGuid(BufferColumnIndexes[columnIndex]);
        }
        public string GetString(int columnIndex)
        {
            return Buffer.GetString(BufferColumnIndexes[columnIndex]);
        }
        public TimeSpan GetTime(int columnIndex)
        {
            return Buffer.GetTime(BufferColumnIndexes[columnIndex]);
        }
        //to test against componentwrapper?
        public uint GetBlobLength(int columnIndex)
        {
            return Buffer.GetBlobLength(BufferColumnIndexes[columnIndex]);
        }
        public byte[] GetBlobData(int columnIndex, int offset, int count)
        {
            return Buffer.GetBlobData(BufferColumnIndexes[columnIndex], offset, count);
        }
        public void AddBlobData(int columnIndex, byte[] data)
        {
            Buffer.AddBlobData(columnIndex, data);
        }
        public void AddBlobData(int columnIndex, byte[] data, int count)
        {
            Buffer.AddBlobData(columnIndex, data, count);
        }
        public void ResetBlobData(int columnIndex)
        {
            Buffer.ResetBlobData(columnIndex);
        }
        public void SetBoolean(int columnIndex, bool value)
        {
            Buffer.SetBoolean(columnIndex, value);
        }
        public void SetByte(int columnIndex, byte value)
        {
            Buffer.SetByte(columnIndex, value);
        }
        public void SetBytes(int columnIndex, byte[] bytesValue)
        {
            Buffer.SetBytes(columnIndex, bytesValue);
        }
        public void SetDate(int columnIndex, DateTime value)
        {
            Buffer.SetDate(columnIndex, value);
        }
        public void SetDateTime(int columnIndex, DateTime value)
        {
            Buffer.SetDateTime(columnIndex, value);
        }
        public void SetDateTimeOffset(int columnIndex, DateTimeOffset value)
        {
            Buffer.SetDateTimeOffset(columnIndex, value);
        }
        public void SetDecimal(int columnIndex, decimal value)
        {
            Buffer.SetDecimal(columnIndex, value);
        }
        public void SetDouble(int columnIndex, double value)
        {
            Buffer.SetDouble(columnIndex, value);
        }
        public void SetGuid(int columnIndex, Guid value)
        {
            Buffer.SetGuid(columnIndex, value);
        }
        public void SetInt16(int columnIndex, short value)
        {
            Buffer.SetInt16(columnIndex, value);
        }
        public void SetInt32(int columnIndex, int value)
        {
            Buffer.SetInt32(columnIndex, value);
        }
        public void SetInt64(int columnIndex, long value)
        {
            Buffer.SetInt64(columnIndex, value);
        }
        public void SetSByte(int columnIndex, sbyte value)
        {
            Buffer.SetSByte(columnIndex, value);
        }
        public void SetSingle(int columnIndex, float value)
        {
            Buffer.SetSingle(columnIndex, value);
        }
        public void SetString(int columnIndex, string value)
        {
            Buffer.SetString(columnIndex, value);
        }
        public void SetTime(int columnIndex, TimeSpan value)
        {
            Buffer.SetTime(columnIndex, value);
        }
        public void SetUInt16(int columnIndex, ushort value)
        {
            Buffer.SetUInt16(columnIndex, value);
        }
        public void SetUInt32(int columnIndex, uint value)
        {
            Buffer.SetUInt32(columnIndex, value);
        }
        public void SetUInt64(int columnIndex, ulong value)
        {
            Buffer.SetUInt64(columnIndex, value);
        }
    }
    #endregion
