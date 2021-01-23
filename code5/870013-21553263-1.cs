    string s = YourLabelControl.Text;
    int i;
    if(Int32.TryParse(s, out i))
    {
      int abs = Math.Abs(i);
    }
    else
    {
      //Your Label value is not a valid int.
    }
