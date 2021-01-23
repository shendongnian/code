    private static void Main(string[] args)
    {
        //...
        Console.WriteLine("Updating");
        RunQuery(@"UPDATE dbo.IMAGE
                   SET PIXEL_HEIGHT = @Height, PIXEL_WIDTH = @Width, SIZE = @Size
                   WHERE IMAGE_NO = @ImageNo", p =>
                 {
                      p.Add("@Height", SqlDbType.Int).Value = Height;
                      p.Add("@Width", SqlDbType.Int).Value = Width;
                      p.Add("@Size", SqlDbType.Int).Value = Size;
                      p.Add("@ImageNo", SqlDbType.Int).Value = imageNo;
                 });
    }
             
