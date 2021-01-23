    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using Org.BouncyCastle.Asn1;
    public class AsnTest {
        public static void Main() {
            var certificate = new X509Certificate2(File.ReadAllBytes("Test.x509"));
            foreach (var ext in certificate.Extensions) {
                // This is as far as we reliably get with native .NET libraries, switch to BouncyCastle for additional parsing
                var o = new Asn1InputStream(ext.RawData).ReadObject();
                var q = new Queue<Asn1Sequence>();
                var i = new List<DerObjectIdentifier>();
                if (o is Asn1Sequence) {
                    q.Enqueue(o as Asn1Sequence);
                } else if (o is DerObjectIdentifier) {
                    i.Add(o as DerObjectIdentifier);
                }
                while (q.Any()) {
                    var s = q.Dequeue();
                    i.AddRange(s.OfType<DerObjectIdentifier>());
                    foreach (var n in s.OfType<Asn1Sequence>())
                    {
                        q.Enqueue(n);
                    }
                }
                if (i.Any()) {
                    Console.WriteLine("Found the follwing OID value(s) in the " + ext.Oid.Value + " extension: " + string.Join(", ", i.Select(j => j.Id)));
                } else {
                    Console.WriteLine("Found no OID values in the " + ext.Oid.Value + " extension.");
                }
            }
        }
    }
