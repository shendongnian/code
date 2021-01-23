     class StreamWriterWithPosition : StreamWriter {
       override void Write(Char c) { pos++; base.Write(c);}
       override void Write(Char[] ca) {pos+= ca.Length; base.Write(ca);}
       override void Write(Char[] ca,Int32 offset,Int32 len) { pos+= len; base.Write(ca,offset,len);}
       override void Write(String s) { pos += s.Length;base.Write(s);}
       int pos = 0;
     }
