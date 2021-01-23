        bool isBookingRecordFound = false;
        while ((line = file.ReadLine()) != null)
        {
              if (line.Contains(txt_SearchBooking.Text)) //Will always match line Booking Number :KW2MSMB30
              {
                   isBookingRecordFound = true; //True here will ensure there was a record found
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
        if (!isBookingRecordFound)
           MessageBox.Show("There was no matching booking number");
