    using System;
    using System.Collections.Concurrent;
    using System.IO;
    
    namespace Example
    {
        public class BufferStream : Stream
        {
            public BufferStream()
            {
                _data = new BlockingCollection<byte[]>();
            }
    
    
            /// <param name="boundedCapacity">The maximum number of calls to <see cref="Write"/> that can be made without
            /// the buffer being drained.</param>
            public BufferStream(int boundedCapacity)
            {
                _data = new BlockingCollection<byte[]>(boundedCapacity);
            }
    
            private readonly BlockingCollection<byte[]> _data;
            private byte[] _currentBlock = null;
            private int _currentBlockIndex = 0;
    
            public int BoundedCapacity { get { return _data.BoundedCapacity; } }
    
            public int BufferedWrites { get { return _data.Count; } }
    
            public bool IsAddingCompleted
            {
                get { return _data.IsAddingCompleted; }
            }
    
            public bool IsCompleted
            {
                get { return _data.IsCompleted; }
            }
    
            public void CompleteAdding()
            {
                _data.CompleteAdding();
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                var localArray = new byte[count];
                
                //Copy the data in to a new buffer of exactly the count size.
                Array.Copy(buffer, offset, localArray, 0, count);
    
                _data.Add(localArray);
            }
    
            
            public override int Read(byte[] buffer, int offset, int count)
            {
                if (_currentBlock == null || _currentBlockIndex == _currentBlock.Length)
                {
                    if (!GetNextBlock()) 
                        return 0;
                }
    
                int minCount = Math.Min(count, _currentBlock.Length - _currentBlockIndex);
    
                Array.Copy(_currentBlock, _currentBlockIndex, buffer, offset, minCount);
                _currentBlockIndex += minCount;
    
                return minCount;
            }
    
            /// <summary>
            /// Loads the next block in to <see cref="_currentBlock"/>.
            /// </summary>
            /// <returns>True if the next block was retrieved.</returns>
            private bool GetNextBlock()
            {
                if (!_data.TryTake(out _currentBlock))
                {
                    //The TryTake failed, the collection is empty.
    
                    //See if we are in the completed state.
                    if (_data.IsCompleted)
                    {
                        return false;
                    }
    
                    //Wait for more data to show up.
                    try
                    {
                        _currentBlock = _data.Take();
                    }
                    catch (InvalidOperationException)
                    {
                        //If the blocking collection was marked complete while we where waiting Take throws a InvalidOperationException
                        return false;
                    }
                }
    
                _currentBlockIndex = 0;
                return true;
            }
    
            #region Constant functions
    
            public override bool CanRead
            {
                get { return true; }
            }
    
            public override bool CanSeek
            {
                get { return false; }
            }
    
            public override bool CanWrite
            {
                get { return true; }
            }
            
            public override void Flush()
            {
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }
    
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
    
            public override long Length
            {
                get { throw new NotSupportedException(); }
            }
    
            public override long Position
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
    
            #endregion
        }
    }
