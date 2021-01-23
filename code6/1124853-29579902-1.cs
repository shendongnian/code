        public void updateBase(string opcode, string rt, string comma, string imm, string @base)
        {
            int tlen = scintilla1.TextLength; // 12
            int olen = opcode.Length;
            int rlen = rt.Length;
            int clen = comma.Length;
            int ilen = imm.Length;
            int blen = @base.Length;
            int n = 0;
            scintilla1.Text += opcode;
            scintilla1.Text += rt;
            scintilla1.Text += comma;
            scintilla1.Text += imm;
            scintilla1.Text += @base;
            int sumt = tlen + olen;
            while (tlen < sumt)
            {
                n = tlen - 1;
                tlen += 1;
                scintilla1.GetRange(n).SetStyle(1);
            }
            sumt = tlen + rlen;
            while (tlen < sumt)
            {
                n = tlen /*+ 1*/;
                tlen += 1;
                scintilla1.GetRange(n).SetStyle(2);
            }
            sumt = tlen + clen;
            while (tlen < sumt)
            {
                n = tlen /*+ 1*/;
                tlen += 1;
                scintilla1.GetRange(n).SetStyle(3);
            }
            sumt = tlen + ilen;
            while (tlen < sumt)
            {
                n = tlen /*+ 1*/;
                tlen += 1;
                scintilla1.GetRange(n).SetStyle(4);
            }
            sumt = tlen + blen;
            while (tlen < sumt)
            {
                n = tlen /*+ 1*/;
                tlen += 1;
                scintilla1.GetRange(n).SetStyle(5);
            }
        }
