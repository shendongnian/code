    public class IEnumerableStringReader : TextReader
    {
        private readonly IEnumerator<string> _enumerator;
    
        private bool eof = false; // is set to true when .MoveNext tells us there is no more data.
        private char[] curLine = null;
        private int curLinePos = 0;
    
        private bool disposed = false;
    
        public IEnumerableStringReader(IEnumerable<string> input)
        {
            _enumerator = input.GetEnumerator();
        }
                            
        private void GetNextLine()
        {
            if (eof) return;
    
            eof = !_enumerator.MoveNext();
            if (eof) return;
    
            curLine = $"{_enumerator.Current}\r\n" // IEnumerable<string> input implies newlines exist betweent he lines.
                .ToCharArray();
    
            curLinePos = 0;
        }
            
        public override int Peek()
        {
            if (disposed) throw new ObjectDisposedException("The stream has been disposed.");
    
            if (curLine == null || curLinePos == curLine.Length) GetNextLine();
            if (eof) return -1;
    
            return curLine[curLinePos];
        }
            
        public override int Read()
        {
            if (disposed) throw new ObjectDisposedException("The stream has been disposed.");
    
            if (curLine == null || curLinePos == curLine.Length) GetNextLine();
            if (eof) return -1;
    
            return curLine[curLinePos++];
        }
            
        public override int Read(char[] buffer, int index, int count)
        {
            if (disposed) throw new ObjectDisposedException("The stream has been disposed.");
            if (count == 0) return 0;
    
            int charsReturned = 0;
            int maxChars = Math.Min(count, buffer.Length - index); // Assuming we dont run out of input chars, we return count characters if we can. If the space left in the buffer is not big enough we return as many as will fit in the buffer. 
    
            while (charsReturned < maxChars)
            {
                if (curLine == null || curLinePos == curLine.Length) GetNextLine();
                if (eof) return charsReturned;
    
                int maxCurrentCopy = maxChars - charsReturned;
                int charsAtTheReady = curLine.Length - curLinePos; // chars available in current line                
                int copySize = Math.Min(maxCurrentCopy, charsAtTheReady); // stop at end of buffer.
    
                // cant use Buffer.BlockCopy because it's byte based and we're dealing with chars.                
                Array.ConstrainedCopy(curLine, curLinePos, buffer, index, copySize);
    
                index += copySize;
                curLinePos += copySize;
                charsReturned += copySize;
            }
    
            return charsReturned;
        }
            
        public override string ReadLine()
        {
            if (curLine == null || curLinePos == curLine.Length) GetNextLine();
            if (eof) return null;
    
            if (curLinePos > 0) // this is necessary in case the client uses both Read() and ReadLine() calls
            {
                var tmp = new string(curLine, curLinePos, (curLine.Length - curLinePos) - 2); // create a new string from the remainder of the char array. The -2 is because GetNextLine appends a crlf.            
                curLinePos = curLine.Length; // so next call will re-read
                return tmp;
            }
    
            // read full line.
            curLinePos = curLine.Length; // so next call will re-read
            return _enumerator.Current; // if all the client does is call ReadLine this (faster) code path will be taken.                       
        }
    
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                _enumerator.Dispose();
                base.Dispose(disposing);
                disposed = true;
            }
        }
    }
