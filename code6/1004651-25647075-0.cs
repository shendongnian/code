    var e = Encoding.GetEncoding("iso-8859-1");
                var bytes = Encoding.GetEncoding(1252).GetBytes("~recÛßå ^ÿìü P  pÀ 0Ðÿp àÀ^^ÚÞâ ^ÿòüü P ÿ ÿà 0ÿ 0ÿÐ € `^^ÚÞã hÿòüü T usw.");
                var s = e.GetString(bytes);
    
                var hexchars = "";
                for (int i = 0; i < bytes.Length; i++ )
                {
                    hexchars += (bytes[i]).ToString("X2");
                }
