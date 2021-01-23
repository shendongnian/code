        [Test]
        public void ProtobufTestNameSerializeDeserialize()
        {
            ProtobufTest<double, double> t = new ProtobufTest<double, double>("233");
            ProtobufTest<double, double> d;
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.SerializeWithLengthPrefix(ms, t, PrefixStyle.Base128);
                ms.Position = 0;
                d = Serializer.DeserializeWithLengthPrefix<ProtobufTest<double, double>>(ms, PrefixStyle.Base128);
            }
            Assert.AreEqual(t.Name, d.Name);
        }
