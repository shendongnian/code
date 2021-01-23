    private void btnAcc_Click(object sender, EventArgs e)
    {
         GetCarData(car);
         car.Accelerate += speed;
         MessageBox.Show(" Your car is a " + car.year + car.make + " and it is traveling " + speed + " mph. ");
    }
