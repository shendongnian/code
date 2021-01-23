    var gids = new List<Guid>();
    for (long i = 1; i < 10000; i++)
    { 
         // Skip any values that we don't want
         if ((float)i / 16 % 1 >= 0.625)
         {
             i += 5;
             continue;
         }
         var bytes = new byte[16];
         var lngBytes = BitConverter.GetBytes(i);
         Array.Copy(lngBytes, bytes, 8);
         Array.Reverse(bytes);
         gids.Add(new Guid(bytes));
     }
