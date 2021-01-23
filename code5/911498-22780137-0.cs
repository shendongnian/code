    var ci = CultureInfo.GetCultureInfo(Request.UserLanguages[0]);
    TimeSpan ts;
    if (TimeSpan.TryParse(txtYourTime.Text, ci, out ts)) {
      cmd.Parameters.Add("@YourTime", SqlDbType.Time).Value = ts;
    } else {
      // Report invalid input to user.
    }
