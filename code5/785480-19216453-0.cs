        enum Conversions
        {
            Inch = 1,
            Foot = 12,
            Yard = 36
        }
       private void convertButton_Click(object sender, EventArgs e)
        {
            int fromDistance;
            int toDistance;
    
            fromDistance = int.Parse(distanceInput.Text);
            Conversions measureinput = ((Conversions)Enum.Parse(typeof(Conversions), fromList.Items[fromList.SelectedIndex].ToString());
            Conversions measureoutput = (Conversions)Enum.Parse(typeof(Conversions), toList.Items[toList.SelectedIndex].ToString());
            toDistance = (fromdistance * (int)measureinput) / (int)measureoutput;
    
            distanceOutput.Text = toDistance.ToString();
        }
