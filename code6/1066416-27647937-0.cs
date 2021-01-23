            Encoding iso = Encoding.GetEncoding("iso-8859-5");
            Encoding utf = Encoding.UTF8;
            var isoBytes = new byte[] { 228, 232 }; // фш
            // iso to utf8
            var utfBytes = Encoding.Convert(iso, utf, isoBytes);
            // utf8 to iso
            var isoBytes2 = Encoding.Convert(utf, iso, utfBytes);
            // get all strings (with the correct encoding)
            // all 3 strings will contain фш
            string s1 = iso.GetString(isoBytes);
            string s2 = utf.GetString(utfBytes);
            string s3 = iso.GetString(isoBytes2);
