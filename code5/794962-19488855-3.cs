    string sid = lb1.SelectedItem.ToString();
    try
    {
        lb1.IsEnabled = false;
        var series = await LoadSeriesAsync(Int32.Parse(sid));
        UpdateSeries(series);
    }
    catch (FormatException)
    {
        MessageBox.Show("Please enter a valid series id");
        lb1.IsEnabled = true;
    }
}
