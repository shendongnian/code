        SqlCommand taxafter30k = new SqlCommand("Select taxafter30k from TaxValue");
        SqlCommand taxafter50k = new SqlCommand("Select taxafter50k from TaxValue");
        SqlDataReader dr;
        double taxafter30kNew = Convert.ToDouble(taxafter30k.ExecuteScalar());
        double taxafter30kNew = Convert.ToDouble(taxafter50k.ExecuteScalar());
       
            double totalcartaxOMV = 0d;
            if (carValue <= 20000)
            {
                totalcartaxOMV = carValue;
            }
            else if (carValue > 20000 && carValue <= 50000)
            {
                totalcartaxOMV = ((20000 + ((carValue - 20000) * taxafter30kNew)));
            }
            else if (carValue > 50000)
            {
                totalcartaxOMV = (20000 + 42000 + ((carValue - 50000) * taxafter50kNew));
            }
            con.Close();
            return totalcartaxOMV;
        
