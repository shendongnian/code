    FooImplementing foo = new FooImplementing("Behzad");
    var blindedMessage = foo.blindTheMessage(textBox2);
    var userSignature = foo.signedWithRsa(blindedMessage);
    if (foo.verifyRsaSignedData(blindedMessage, userSignature))
    {
         var signedMessage = foo.blindSignature(blindedMessage);
         var unblindedMessage = foo.unblindeTheSignedData(signedMessage);
         MessageBox.Show(foo.verifyBlindSignature(unblindedMessage, textBox3).ToString());
     }
