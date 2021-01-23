    private static String GetBase64Alternate(string text) {
      Encoding e = Encoding.GetEncoding(1252, new EncoderExceptionFallback(), new DecoderExceptionFallback());
      bool ok = true;
      try {
        e.GetByteCount(allIn);
      } catch (EncoderFallbackException) {
        ok = false;
      }
      return ok ? null : Convert.ToBase64(Encoding.UTF8.GetBytes(text));
    }
