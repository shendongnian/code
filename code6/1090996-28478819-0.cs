    public object arrayq (int d)
    {
        if(d=1)
        {
            Q2.Visible = true;
            question2.Visible = true;
            question1.Visible = false;
            Q1.Visible = false
        }
        else if(d=2){
            question3.Visible = true
        }
        object[] question = new object[3];
        question[0] = Q1.Text;
        question[1] = Q2.Text;
        question[2] = Q3.Text ;
        return question[d];
    }
