      string base64string = Convert.FromBase64String(Textbox1.Text.ToString.Split(',')[1]);
      //Convert base64string to bytes array
       Byte[] bytes = Convert.FromBase64String(base64string);
       gif = iTextSharp.text.Image.GetInstance(bytes);
}
