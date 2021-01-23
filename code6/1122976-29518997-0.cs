            var sum = 0.0;
            var divisor = 0;
            if (!string.IsNullOrEmpty(cb6.Text))
            {
                sum += Convert.ToDouble(cb6.Text);
                divisor++;
            }
            if (!string.IsNullOrEmpty(cb7.Text))
            {
                sum += Convert.ToDouble(cb7.Text);
                divisor++;
            }
            if (!string.IsNullOrEmpty(cb8.Text))
            {
                sum += Convert.ToDouble(cb8.Text);
                divisor++;
            }
            if (divisor > 0)
            {
                txtaverage.Text = (sum/divisor).ToString();
            }
