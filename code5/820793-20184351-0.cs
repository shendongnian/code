    btn1.Click += button_Click;
    btn2.Click += button_Click;
    btn3.Click += button_Click;
    
     private void button_Click(object sender, EventArgs e)
     {
    	var btn = sender as Button;
    	if (sender != null) {
			if (btn is btn1) {
				//do something
			}
			else if (btn is btn2) {
				//do something
			}
			//etc
		}
     }
