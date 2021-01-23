    var text = "Variable text";
    var img = new MagickImage("image.jpg");
    using (var imgText = new MagickImage())
    {
         imgText.FontPointsize = 50;
         imgText.BackgroundColor = new MagickColor(Color.Black);
         imgText.FillColor = new MagickColor(Color.White);
         imgText.Read("label:" + text);
         img.Composite(text, Gravity.Northwest);
    }
