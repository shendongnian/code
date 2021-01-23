            double parts;
            double labor;
            if(
               double.TryParse(partsTextBox.Text, out parts)
               && double.TryParse(laborTextBox.Text, out labor))
            {
                double oillube = OilLubeCharges(oil, lube);
                double flush = FlushCharges(radiator, trans);
                double misc = MiscCharges(inspection, muffler, tire);
                double other = OtherCharges(parts, labor);
                double tax = TaxCharges(parts, labor, oillube, flush, misc, labor);
                double total = TotalCharges(oillube, flush, misc, other, tax);
                double services = oillube + flush + misc;
                servicesOutputLb.Text = services.ToString("c");
                partsOutputLb.Text = other.ToString("c");
                taxOutputLb.Text = tax.ToString("c");
                totalOutputLb.Text = total.ToString("c");
            }
            else
            {
                MessageBox.Show("Quantity of parts and quantity of labors must be informed and must be valid!");
            }
