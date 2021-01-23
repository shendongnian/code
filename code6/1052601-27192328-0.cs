    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    var exclude = new HashSet<byte[]>();
    var sha1 = new SHA1CryptoServiceProvider();
    // read exclusion emails
    using (var sr = new StreamReader("exclude-file")) {
        string line;
        // assume one email per line of text
        while ((line = sr.ReadLine()) != null) {
            exclude.Add(sha1.ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(line))));
        }
    }
    // read emails
    using (var sr = new StreamReader("email-file")) {
        string line;
        // again, assume one email per line of text
        while ((line = sr.ReadLine()) != null) {
            if (exclude.Contains(sha1.ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(line))))) {
                // exclusion file contains email
            } else {
                // exclusion file does not contain email
            }
        }
    }
