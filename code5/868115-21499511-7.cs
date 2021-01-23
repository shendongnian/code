    while ((line = file.ReadLine()) != null)
        {
              if (line.Contains(txt_SearchBooking.Text)) //Will always match line Booking Number :KW2MSMB30
              {
                   sb.AppendLine(line.ToString());
                   while ((line = file.ReadLine()) != null)
                   {
                       if (line.Contains("Booking Number :"))
                           break;
                       
                       sb.AppendLine(line.ToString());
                   }
              }
              lbl_result.Text = sb.ToString();
        }
