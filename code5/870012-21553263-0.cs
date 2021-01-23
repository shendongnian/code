    string s = YourLabelControl.Text;
    int abs, i;
    if(Int32.TryParse(s, out i))
    {
      abs = Math.Abs(i);
    }
    else
    {
      //Your Label value is not a valid int.
    }
