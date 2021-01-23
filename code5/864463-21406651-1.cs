    using(var iterator = listOfRadioButtons.Where(rb => rb.IsChecked == true))
    {
        while(iterator.MoveNext())
        {
            RadioButton item = iterator.Current;
            // something
        }
    }
