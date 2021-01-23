    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    var exclude = new List<byte[]>();
    var sha1 = new SHA1CryptoServiceProvider();
    // read exclusion emails
    using (var sr = new StreamReader("exclude-file")) {
        string email;
        // assume one email per line of text
        while ((email = sr.ReadLine()) != null) {
            exclude.Add(sha1.ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(email))));
        }
    }
    // read emails
    using (var sr = new StreamReader("email-file")) {
        string email;
        // again, assume one email per line of text
        while ((email = sr.ReadLine()) != null) {
            if (exclude.Contains(sha1.ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(email))))) {
                // exclusion file contains email
            } else {
                // exclusion file does not contain email
            }
        }
    }
