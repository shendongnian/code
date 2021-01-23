    var divcontrols = myValueDiv.Controls.OfType<HtmlGenericControl>();
        foreach(HtmlGenericControl loHTML in divcontrols)
        {
            var checkedRadioButtons = loHTML.Controls.OfType<RadioButton>().Where(radButton => radButton.Checked).ToList();
            foreach (RadioButton lobtn in checkedRadioButtons)
            {
                Response.Write(lobtn.Text);
            }
        }
