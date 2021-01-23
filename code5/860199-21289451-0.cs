                var chrs = System.Text.Encoding.ASCII.GetChars( new byte[]{0174});
                var chrsUtf = System.Text.Encoding.UTF8.GetChars(new byte[] { 0174 });
                var chrsUnicode = System.Text.Encoding.Unicode.GetChars(new byte[] { 0174 }); 
                Debug.WriteLine(chrs[0].ToString());
                Debug.WriteLine(chrsUtf[0].ToString());
                Debug.WriteLine(chrsUnicode[0].ToString());
