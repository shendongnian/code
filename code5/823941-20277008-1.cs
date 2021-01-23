    //Conversion object
    System.Text.UTF8Encoding  encoding = new System.Text.UTF8Encoding();
    
    //Your any String text
    String stringText = "g" + Convert.ToChar(0) + "poo";
    
    //Convert to the wanted byte array
    byte[] byteArray = encoding.GetBytes(stringText);
