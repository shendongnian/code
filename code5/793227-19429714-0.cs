      static private void Function()
      {
         Console.WriteLine("before");
         using (SecureString s = new SecureString())
            s.Clear();
         Console.WriteLine("after");
      }
