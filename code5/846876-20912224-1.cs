    int val, val1, val2;
    if (oneValue.IsChecked)
    {
        if (int.TryParse(first.Text, val))
        {
           showTotal(val);
        }
     }
      else if (twoValues.IsChecked)
      {
        if (int.TryParse(second.Text, val1))
        {
           showTotal(val, val1);
        }
      }
      else if (threeValues.IsChecked)
      {
        if (int.TryParse(third.Text, val2)
        {
           showTotal(val, val1, val2);
        }
      }
