     private void dateTimePickerBillDate_ValueChanged(object sender, EventArgs e)
            {
                DateTime pickdt = Convert.ToDateTime(dateTimePickerBillDate.Text);
                maskedtxtBillDate.Text = pickdt.ToString();
            }
