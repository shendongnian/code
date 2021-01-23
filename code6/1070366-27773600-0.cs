    class Number {
      string dec;
    
      byte binary() {
        return System.Text.Encoding.ASCII.GetBytes(this.dec);
      }
    }
