    [TestMethod]
    public void EncodeAndDecodePwd()
    {
      const string pwd = "testpassword";
      string encodedPassword = EncodePassword(pwd);
      string decodedPassword = DecodePassword(encodedPassword);
      string decodedPassword2 = DecodePassword("dGVzdHBhc3N3b3Jk");
      Assert.AreEqual(pwd, decodedPassword);
      Assert.AreEqual(pwd, decodedPassword2);
      Assert.AreEqual(encodedPassword, "dGVzdHBhc3N3b3Jk");
    }
