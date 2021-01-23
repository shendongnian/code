        private void NewList()
        {
            foreach (var key in _fromToD.Reverse())
            {
                _fromTo.Add(new pass(key.Key, GetByteRecursive(key.Key)));
            }
        }
        private byte GetByteRecursive(byte p)
        {
            byte next = p;
            if (_fromToD.ContainsKey(p))
            {
                next = _fromToD[p].Last();
                return GetByteRecursive(next);
            }
            else
            {
                return next;
            }
        }
        class pass
        {
            public byte from;
            public byte to;
            public pass(byte from, byte to)
            {
                this.from = from;
                this.to = to;
            }
        }
        unsafe class pixel
        {
            public byte* pix;
            public byte color;
            public pixel(byte* pixel, byte color)
            {
                this.pix = pixel;
                this.color = color;
            }
        }
