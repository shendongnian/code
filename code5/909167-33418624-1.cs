    private class ManagedIStream : IStream
    {
        private Stream _stream;
        public ManagedIStream(Stream stream)
        {
            _stream = stream;
        }
        public void Clone(out IStream ppstm)
        {
            throw new NotImplementedException();
        }
        public void Commit(int grfCommitFlags)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
        {
            throw new NotImplementedException();
        }
        public void LockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new NotImplementedException();
        }
        public void Read(byte[] pv, int cb, IntPtr pcbRead)
        {
            int read = _stream.Read(pv, 0, cb);
            if (pcbRead != IntPtr.Zero)
            {
                Marshal.WriteInt32(pcbRead, read);
            }
        }
        public void Revert()
        {
            throw new NotImplementedException();
        }
        public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
        {
            long newPos = _stream.Seek(dlibMove, (SeekOrigin)dwOrigin);
            if (plibNewPosition != IntPtr.Zero)
            {
                Marshal.WriteInt64(plibNewPosition, newPos);
            }
        }
        public void SetSize(long libNewSize)
        {
            _stream.SetLength(libNewSize);
        }
        public void Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, int grfStatFlag)
        {
            const int STGTY_STREAM = 2;
            pstatstg = new System.Runtime.InteropServices.ComTypes.STATSTG();
            pstatstg.type = STGTY_STREAM;
            pstatstg.cbSize = _stream.Length;
            pstatstg.grfMode = 0;
            if (_stream.CanRead && _stream.CanWrite)
            {
                const int STGM_READWRITE = 0x00000002;
                pstatstg.grfMode |= STGM_READWRITE;
                return;
            }
            if (_stream.CanRead)
            {
                const int STGM_READ = 0x00000000;
                pstatstg.grfMode |= STGM_READ;
                return;
            }
            if (_stream.CanWrite)
            {
                const int STGM_WRITE = 0x00000001;
                pstatstg.grfMode |= STGM_WRITE;
                return;
            }
            throw new IOException();
        }
        public void UnlockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new NotImplementedException();
        }
        public void Write(byte[] pv, int cb, IntPtr pcbWritten)
        {
            _stream.Write(pv, 0, cb);
            if (pcbWritten != IntPtr.Zero)
            {
                Marshal.WriteInt32(pcbWritten, cb);
            }
        }
    }
