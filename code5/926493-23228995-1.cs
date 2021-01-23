       private void btnAcc_Click(object sender, EventArgs e)
        {
            GetCarData(_car);
            _car.Accelerate(); //note the way you were using won't work on this line
            MessageBox.Show(" Your car is a " + _car.year + _car.make + " and it is traveling " + speed + " mph. ");
        }
