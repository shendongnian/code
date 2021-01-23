    btnCalc.Click += (object sender, EventArgs e) => {
    int input1 =0;
    int input2 =0;
    Int32.TryParse(input1.Text, out input1);
    Int32.TryParse(input2.Text, out input2);
 
    totalScore = input1+ input2;
    total.Text = totalScore.ToString();
    };
