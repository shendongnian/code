    btnCalc.Click += (object sender, EventArgs e) => {
    int input1 =0;
    int input2 =0;
    try{
       input1 = Convert.ToInt32(input1.Text);
    }
    catch{
    // do nothing, the input1 will remain 0
    }
    try{
       input2 = Convert.ToInt32(input2.Text);
    }
    catch{
    // do nothing, the input2 will remain 0
    }
    
        totalScore = input1+ input2;
        total.Text = totalScore.ToString();
    };
