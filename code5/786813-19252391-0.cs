    txtStartDate.Text = GetStartDate(Employee.CurrentLongTermIncentive.StartDate);
    private string GetStartDate(DateTime? startDate)
    {
            if (startDate != null)
            {
                return startDate.Value.ToShortDateString();
            }
            return "";
    }
