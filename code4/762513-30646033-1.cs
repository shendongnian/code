                    //    piWatermark.SetValue(dateTextBox, this.Watermark, null);
                    //}
                    var partWatermark = dateTextBox.Template.FindName("PART_Watermark", dateTextBox) as ContentControl;
                    if (partWatermark != null)
                    {
                        partWatermark.Foreground = new SolidColorBrush(Colors.Gray);
                        partWatermark.Content = this.Watermark;
                    }
                }
            }
        }
