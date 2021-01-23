    DateTime dateTime;
    if (DateTime.TryParse("2014-05-26T11:15:00+0200", out dateTime))
    {
        lblv1.Text = string.Format("{0}:{1}", dateTime.Hour, dateTime.Minute);
    }
