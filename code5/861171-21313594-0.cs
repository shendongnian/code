    private void button1_Click(object sender, EventArgs e)
    {
        using(var context = new DbContext())
        {
            Car CarToCreate = new Car();
            CarToCreate.Name = newCarNameTextBox.Text;
            CarToCreate.CarClass = newCarClassComboBox.SelectedItem.ToString();
            CarToCreate.PricePerDay = Convert.ToDecimal(newCarPriceTextBox.Text);
            CarToCreate.Capacity = Convert.ToInt32(newCarCapacityTextBox.Text);
            CarToCreate.RegistrationNumber = newCarRegNumberTextBox.Text;
            CarToCreate.Description = newCarDescriptionTextBox.Text;
            CarToCreate.CarState = "Available";
    
            context.Cars.InsertOnSubmit(CarToCreate);
            context.SubmitChanges();
        }
    
        CarModifiedEvent();
        this.Close();
    }
