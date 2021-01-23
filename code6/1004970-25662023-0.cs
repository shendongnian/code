       class StackOverflow
       {
          byte[] unibytes;  // To be replaced by your data
    
          public void JustTesting()
          {
             string s;
             
             // Single-step these under the debugger, examine s after each attempt to see what works
             s = Encoding.Unicode.GetString(unibytes);
             s = Encoding.UTF8.GetString(unibytes);
             s = Encoding.BigEndianUnicode.GetString(unibytes);
    
             // Once you have the correct decoding, re-encode to code page 865
             byte[] asciiLikeByteArray = Encoding.GetEncoding(865).GetBytes(s);
          }
       }
