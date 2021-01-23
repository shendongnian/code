    public static void TrimTextControls(this Control parent, bool TrimLeading)
    {
      foreach (TextBox txt in parent.GetAllControls().OfType<TextBox>())
      {
        if (TrimLeading)
        {
          txt.Text = txt.Text.Trim();
        }
        else
        {
          txt.Text = txt.Text.TrimEnd();
        }
      }
    }
