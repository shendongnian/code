     var data = (byte[])FailData.Properties["VendorSpecific"].Value;
     var sb = new StringBuilder();
     for(var i = 0; i < data[0]-1; i++)
     {
       sb.Append(data[i+1] + "\t");
       if((i % 12)==11) sb.AppendLine();
     }
     File.WriteAllText(@"c:\folder\file.txt", sb.ToString());
