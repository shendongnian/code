	using PKI.ASN;
	using System;
	using System.Collections.Generic;
	using System.Security.Cryptography;
	using System.Security.Cryptography.X509Certificates;
	using System.Text;
	namespace MyNamespace {
		public class RdnAttribute {
			public Oid OID { get; set; }
			public String Value { get; set; }
		}
		public class MyClass {
			public static List<RdnAttribute> GetRdnAttributes(X500DistinguishedName name) {
				List<RdnAttribute> retValue = new List<RdnAttribute>();
				ASN1 asn = new ASN1(name.RawData);
				asn.MoveNext();
				do {
					ASN1 asn2 = new ASN1(asn.Payload);
					asn2.MoveNext();
					List<Byte> oidRawData = new List<Byte>(asn2.Header);
					oidRawData.AddRange(asn2.Payload);
					Oid oid = ASN1.DecodeObjectIdentifier(oidRawData.ToArray());
					asn2.MoveNext();
					String value;
					switch (asn2.Tag) {
						case (Byte)ASN1Tags.UniversalString:
							value = Encoding.UTF32.GetString(asn2.Payload);
							break;
						case (Byte)ASN1Tags.BMPString:
							value = Encoding.BigEndianUnicode.GetString(asn2.Payload);
							break;
						default:
							value = Encoding.UTF8.GetString(asn2.Payload);
							break;
					}
					retValue.Add(new RdnAttribute { OID = oid, Value = value });
				} while (asn.MoveNextCurrentLevel());
				return retValue;
			}
		}
	}
