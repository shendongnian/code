    string sid = lb1.SelectedItem.ToString();
    try
    {
        lbl.Enabled = false;
        var series = await LoadSeriesAsync(Int32.Parse(sid));
        UpdateSeries(series);
    }
    catch (FormatException)
    {
        MessageBox.Show("Please enter a valid series id");
        lbl.Enabled = true;
    }
}
