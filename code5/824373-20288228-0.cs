    internal class ReadLinesIterator : Iterator<string>
    {
        private StreamReader _reader;
    
        public override bool MoveNext()
        {
            if (this._reader != null)
            {
                base.current = this._reader.ReadLine();
                if (base.current != null)
                    return true;
                base.Dispose();
            }
            return false;
        }
    }
