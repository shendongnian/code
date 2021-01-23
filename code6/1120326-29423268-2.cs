    else if (_dMiSd < 0.086)
    {
        //I suggest you to specify which input exactly is faulty
        throw new ArgumentException("Error - check input");
    }
    void Button1_Click(...){
        try{
            if(radioButton1.Checked){
                RadioButton1Checked();
            }
            if(radioButton2.Checked){
                SomeOtherFunction();
            }
            ...
        }catch(ArgumentException e){
            MessageBox.Show(e.Message);
        }
    }
