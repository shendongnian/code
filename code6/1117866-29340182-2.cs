    public class RowController
    {
    public ComboBox Rate{get;private set;}
    public TextBox Hours{get;private set;}
    public TextBox Amount{get;private set;}
    
    public RowController(ComboBox rate,TextBox hours,TextBox amount)
    {
    Rate=rate;
    Hours=hours;
    Hours.TextChange+=OnHoursChanged;
    Amount=amount;
    }
    
    private void OnHoursChanged(object sender,EventArgs args)
    {
     if (Hours.Text.Length > 0)
          { Amount.Text = (GetRate() * double.Parse(Hours.Text)).ToString();}
    }
    
    private double GetRate()
    {
    if (Rate.SelectedValue.ToString() == "Regular")
        {
            return 1.25;
        }
    else if (Rate.SelectedValue.ToString() == "Double")
        {
            return 2;
        }
    }
    }
