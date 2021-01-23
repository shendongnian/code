    byte[] HexStringToByteArray(string input) {
      Debug.Assert(input.Length % 2 == 0, "Must have two digits per byte");
      var res = new byte[input.Length/2];
      for (var i = 0; i < input.Length/2; i++) {
        var h = input.Substring(i*2, 2);
        res[i] = Convert.ToByte(h, 16);
      }
      return res;
    }
