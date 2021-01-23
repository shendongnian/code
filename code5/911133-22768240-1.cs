      protected void Page_Load(object sender, EventArgs e)
      {
          for (int i = 0; i < 10; i++) // Create 10 buttons
          {
              buttons[i] = new Button(); // New button
              buttons[i].ID = "Button" + i; // Button id
              buttons[i].Text = "Button " + i; // Button text
              buttons[i].Click += (c, cArgs) => //Set Event
              {
                 TextBox1.Text += "Hi"; //Doesn't show me result.Why???
              };
              buttons[i].Visible = false; // Set visibility to false
              form1.Controls.Add(buttons[i]); // Add button to form1
          }
          int val = 0;
          Button b = new Button(); // Create new button
          b.ID = "BT1"; // Set button id "BT1"
          b.Text = "Click"; // Set on button text
          form1.Controls.Add(b); // add this button to form1
          b.Click += (k, kArgs) => // Give this button event with parameters
          {
              val = Convert.ToInt32(TextBox1.Text); // Convert value of TextBox1  to int32 and set this value to variable "val"
              buttons[val].Visible = true; // Set visibility to true
          };
      }
