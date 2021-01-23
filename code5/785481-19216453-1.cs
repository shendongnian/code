        enum Conversions
        {
            Inches = 1,
            Feet = 12,
            Yards = 36
        }
       private void convertButton_Click(object sender, EventArgs e)
        {
            int fromDistance = 0;
            int toDistance = 0;
    
            fromDistance = int.Parse(distanceInput.Text);
            Conversions measureinput = ((Conversions)Enum.Parse(typeof(Conversions), fromList.Items[fromList.SelectedIndex].ToString());
            Conversions measureoutput = (Conversions)Enum.Parse(typeof(Conversions), toList.Items[toList.SelectedIndex].ToString());
            toDistance = (fromdistance * (int)measureinput) / (int)measureoutput;
    
            distanceOutput.Text = toDistance.ToString()+ " " + Enum.GetName(typeof(Conversions), measureoutput);
        }
