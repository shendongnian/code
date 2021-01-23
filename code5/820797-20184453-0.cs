    public enum Operation {
      Add,
      Subtract,
      Divide,
      Multiply,
      Modulo
    }
    Random rand = new Random();
    private decimal GenerateQuestion(Operation o){
      int a = rand.Next(6, 11);
      int b = rand.Next(1, 6);
      decimal result = 0;
      string os = "";
      switch(o){
        case Operation.Add:          
             result = a + b;
             os = "+";
             break;
        case Operation.Subtract:
             result = a - b;
             os = "-";
             break;
        case Operation.Multiply: 
             result = a * b;
             os = "*";
             break;
        case Operation.Divide:
             result = (decimal)a/b;
             os = "/";
             break;
        case Operation.Modulo:
             result = a % b;
             os = "%";
             break;
      }
      textBox1.Text = string.Format("What is {0} {1} {2}?", a,os,b);
      return result;
    }
    decimal result;    
    private void button1_Click(object sender, EventArgs e)
    {
       result = GenerateQuestion(Operation.Add);
    }
    private void button2_Click(object sender, EventArgs e){
       result = GenerateQuestion(Operation.Subtract);
    }
    private void button3_Click(object sender, EventArgs e){
       result = GenerateQuestion(Operation.Multiply);
    }
    private void button4_Click(object sender, EventArgs e){
       result = GenerateQuestion(Operation.Modulo); 
    }
    private void button5_Click(object sender, EventArgs e){
       decimal v;
       if(decimal.TryParse(textBox2.Text, out v)){
         textBox3.Text = (v == result) ? "Correct!" : "Incorrect!";
       }else {
         textBox3.Clear();
         MessageBox.Show("Enter a number please!");
       }
    }
