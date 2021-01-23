    private static String infoMessages = "", errorMessages = "";
    public void setFeedback(String message, bool info)
    {
        if (info)
        {
            if (!infoCell.Visible)
            {
                errorCell.Visible = false;
                infoCell.Visible = true;
            }
            infoMessages += String.Format("- {0}<br />", message);
            lblInfo.Text += infoMessages;
        }
        else
        {
            if (!errorCell.Visible)
            {
                infoCell.Visible = false;
                errorCell.Visible = true;
            }
            errorMessages += String.Format("- {0}<br />", message);
            lblError.Text += errorMessages;
        }
    }
