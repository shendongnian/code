     StringBuilder sb = new StringBuilder();
     foreach(var pickupNumber in pickUpNumbers) {
         sb.Append(pickupNumber);
     }
     e.Report.ExportOptions.Email.Body = sb.ToString();
