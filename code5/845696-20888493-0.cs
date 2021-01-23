    private int timeDisplayTip;
    [CategoryAttribute("My properties")]
    public string TimeDisplayTip
    {
        get
        {
            return timeDisplayTip.ToString();
        }
        set
        {
            try
            {
                if (Convert.ToInt32(value).ToString() != value.ToString())
                    throw new FormatException();
                timeDisplayTip = Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
