    public void addMessage(string message, string header) {
      string full_body = header + "\n" + message;
      System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
      Byte[] full_body_bytes = encoding.GetBytes(full_body);
      Message mm = new Message(full_body_bytes);
      
      //do stuff here.
    }
