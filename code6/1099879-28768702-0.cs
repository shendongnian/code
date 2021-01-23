        double value_1 = 0;
        bool double_operation = false;
        bool clickable_decimal = true;
        bool operation_pressed = false;
        bool second_click = false;
        bool second_equals = false;
        String math_operator = "";
        private void btn_Click(object sender, EventArgs e)
        {
            if (second_equals == true)
            {
                txt_display.Text = "0";
                //value_1 = 0;
                second_equals = false;
            }
            if ((txt_display.Text == "0") || (operation_pressed == true))
            {
                txt_display.Clear();
            }
            operation_pressed = false;
            Button btn = (Button)sender;
            txt_display.Text = txt_display.Text + btn.Text;
            double_operation = false;
            
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_display.Text = "0";
            value_1 = 0;
        }
        private void btn_deci_Click(object sender, EventArgs e)
        {
            {
                if (clickable_decimal == true)
                {
                    Button btn = (Button)sender;
                    txt_display.Text = txt_display.Text + btn.Text;
                    clickable_decimal = false;
                }
               
            }
        }
        private void btn_operator_Click(object sender, EventArgs e)
        {
    //==========================================================================
            if (double_operation == true)
            {
                math_operator = "";
                double_operation = false;
                second_click = false; // however it will work without this but i       
                //do not know why so ill leave it in 
            }
     // this is the solution 
     //=========================================================================
            if (double_operation == false)
            {
                if (second_click == false)
                {
                    
                    Button btn = (Button)sender;
                    math_operator = btn.Text;
                    value_1 = double.Parse(txt_display.Text);
                    operation_pressed = true;
                    clickable_decimal = true;
                    second_equals = false;
                }
                if (second_click == true)
                {
                    Button btn = (Button)sender;
                    operation_pressed = true;
                    clickable_decimal = true;
                    switch (math_operator)
                    {
                        case "+":
                            txt_display.Text = (value_1 + double.Parse(txt_display.Text)).ToString();
                            break;
                        case "-":
                            txt_display.Text = (value_1 - double.Parse(txt_display.Text)).ToString();
                            break;
                        case "/":
                            txt_display.Text = (value_1 / double.Parse(txt_display.Text)).ToString();
                            break;
                        case "*":
                            txt_display.Text = (value_1 * double.Parse(txt_display.Text)).ToString();
                            break;
                    }//end switch
                    value_1 = double.Parse(txt_display.Text);
                    math_operator = btn.Text;
                    second_equals = true;
                }
                second_click = true;
            }
            double_operation = true;
            
    }
        private void btn_equals_Click(object sender, EventArgs e)
        {
            if (second_equals == false)
            {
                switch (math_operator)
                {
                    case "+":
                        txt_display.Text = (value_1 + double.Parse(txt_display.Text)).ToString();
                        break;
                    case "-":
                        txt_display.Text = (value_1 - double.Parse(txt_display.Text)).ToString();
                        break;
                    case "/":
                        txt_display.Text = (value_1 / double.Parse(txt_display.Text)).ToString();
                        break;
                    case "*":
                        txt_display.Text = (value_1 * double.Parse(txt_display.Text)).ToString();
                        break;
                }//end switch
                value_1 = double.Parse(txt_display.Text);
                second_click = false;
                second_equals = true;
            }
