         Button btn1 = new Button();
         this.Controls.Add(btn1);
         
         Button btn2 = new Button();
         this.Controls.Add(btn1);
         
         Button btn3 = new Button();
         this.Controls.Add(btn1);
         
         buttonsToDisable.Add(btn1);
         buttonsToDisable.Add(btn2);
         buttonsToDisable.Add(btn3);
         foreach (var control in this.Controls)
         {
            ((Button)control).Enabled = false;
         }
