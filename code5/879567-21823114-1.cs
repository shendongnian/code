                unitstartpositionV += 30;
                ratestartpositionV += 30;
                amtstartpositionV += 30;
                unit = new TextBox();
                rate = new TextBox();
                amt = new TextBox();
                unit.Tag = rate;
                rate.Tag = amt;
                amt.Tag = unit;
                rate.TextChanged += rate_TextChanged;
                unit.TextChanged += unit_TextChanged;
            }
        }
        private void rate_TextChanged(object sender, EventArgs e)
        {
            
            var rate = sender as TextBox;
            var amt = rate.Tag as TextBox;
            var unit = amt.Tag as TextBox;
            Calc(rate.Text, unit.Text, amt);
        }
        private void unit_TextChanged(object sender, EventArgs e)
        {
            var unit = sender as TextBox;
            var rate = unit.Tag as TextBox;
            var amt = rate.Tag as TextBox;
            Calc(rate.Text, unit.Text, amt);
        }
        private void Calc(string rate, string unit, TextBox amt)
        {
            int rateInt;
            if (!int.TryParse(rate, out rateInt)) return;
            int unitInt;
            if (!int.TryParse(unit, out unitInt)) return;
            amt.Text = (rateInt * unitInt).ToString();
        }
