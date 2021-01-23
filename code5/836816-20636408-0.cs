    protected void setParameterList(String parameter, ListBox.SelectedObjectCollection selected, Boolean displayValue = false)
        {
            foreach (Infragistics.Win.ValueListItem item in selected)
            {
                ParameterDiscreteValue param = new ParameterDiscreteValue();
                if (displayValue)
                {
                    param.Value = item.DisplayText;
                }
                else
                {
                    param.Value = item.DataValue;
                }
                report.ParameterFields[parameter].CurrentValues.Add(param);
            }
        }
