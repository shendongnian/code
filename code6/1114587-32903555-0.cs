    private void UpdateSeriesProperties(Series series, SeriesType type, object seriesSource, bool shouldRenewAxes, bool clearOnly)
        {
            if (series != null)
            {
                switch (type)
                {
                    case SeriesType.LineSeries:
                        try
                        {
                            HorizontalAnchoredCategorySeries category = series as HorizontalAnchoredCategorySeries;
                            category.ClearValue(HorizontalAnchoredCategorySeries.ValueMemberPathProperty);
                            category.ClearValue(HorizontalAnchoredCategorySeries.ItemsSourceProperty);
                            if (!clearOnly)
                            {
                                category.SetBinding(HorizontalAnchoredCategorySeries.ValueMemberPathProperty,
                                    new Binding(YMemberPath) { Source = seriesSource });
                                category.SetBinding(HorizontalAnchoredCategorySeries.ItemsSourceProperty,
                                    new Binding(ItemsSourcePath) { Source = seriesSource });
                            }
                            if (shouldRenewAxes)
                            {
                                if (category.XAxis != null)
                                    _owner.Axes.Remove(category.XAxis);
                                if (category.YAxis != null)
                                    _owner.Axes.Remove(category.YAxis);
                                if (!clearOnly)
                                {
                                    CategoryDateTimeXAxis xAxis = new CategoryDateTimeXAxis();
                                    xAxis.LabelSettings = new AxisLabelSettings();
                                    xAxis.SetBinding(CategoryDateTimeXAxis.ItemsSourceProperty,
                                        new Binding(ItemsSourcePath) { Source = seriesSource });
                                    xAxis.SetBinding(CategoryDateTimeXAxis.DateTimeMemberPathProperty,
                                        new Binding(XMemberPath) { Source = seriesSource });
                                    xAxis.Label = "{" + seriesSource.GetType().GetProperty(XMemberPath).GetValue(seriesSource, null) + "}";
                                    xAxis.StrokeThickness = 8;
                                    xAxis.LabelSettings.Extent = 20;
                                    xAxis.LabelSettings.Location = AxisLabelsLocation.OutsideBottom;
                                    xAxis.LabelSettings.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                                    NumericYAxis yAxis = new NumericYAxis();
                                    yAxis.LabelSettings = new AxisLabelSettings();
                                    yAxis.StrokeThickness = 2;
                                    yAxis.LabelSettings.Extent = 40;
                                    yAxis.LabelSettings.Location = AxisLabelsLocation.OutsideLeft;
                                    yAxis.MinimumValue = Convert.ToDouble(seriesSource
                                                                            .GetType()
                                                                            .GetProperty("MinMax")
                                                                            .GetValue(seriesSource, null)
                                                                            .ToString()
                                                                            .Split(';')[0]);
                                    yAxis.MaximumValue = Convert.ToDouble(seriesSource
                                                                            .GetType()
                                                                            .GetProperty("MinMax")
                                                                            .GetValue(seriesSource, null)
                                                                            .ToString()
                                                                            .Split(';')[1]);
                                    if (_owner.Axes.Count == 0)
                                    {
                                        yAxis.LabelSettings.Visibility = System.Windows.Visibility.Visible;
                                        _owner.Axes.Add(xAxis);
                                        _owner.Axes.Add(yAxis);
                                        category.XAxis = xAxis;
                                        category.YAxis = yAxis;
                                    }
                                    else
                                    {
                                        yAxis.LabelSettings.Visibility = System.Windows.Visibility.Hidden;
                                        _owner.Axes.Add(yAxis);
                                        category.XAxis = (Infragistics.Controls.Charts.CategoryAxisBase)_owner.Axes[0];
                                        category.YAxis = yAxis;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
