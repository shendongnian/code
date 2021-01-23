    while ((line = file.ReadLine()) != null)
    {
          if (line.Contains(txt_SearchBooking.Text)) //Will always match line Booking Number :KW2MSMB30
          {
                // This append the text and a newline into the StringBuilder buffer       
                sb.AppendLine(line.ToString());
                lbl_result.Text += sb.ToString();
          }
    }
