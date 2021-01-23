            //bool isNumber = true;
            //true false statement for error checking
            //isNumber = double.TryParse(text4Hours.Text, out outputValue);
            //isNumber = double.TryParse(text4Hours.Text, out outputValue);;
            //isNumber = double.TryParse(text10Hours.Text, out outputValue);
            //if (!isNumber)
            if (!double.TryParse(text4Hours.Text, out outputValue)||
                !double.TryParse(text8Hours.Text, out outputValue)||
                !double.TryParse(text10Hours.Text, out outputValue))
            {
                //error checking for blank text boxes
                //the checking only check if they are double type
                //but not checking the range from 0 to 9
                MessageBox.Show("Enter a number from 0-9");
            }
