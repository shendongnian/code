    var str = @"$KL\U#, $AS\gehaeuse#, $KL\tol_plus#, $KL\tol_minus#";
    string ReturnManipulatedString(string str)
    {
        var list = str.split("$");
    
        string newValues = string.Empty;
     
        foreach (string st in str)
        {
             var temp = st.split("#");
             newValues += ManipulateStuff(temp[0]);
             if (0 < temp.Count();
                 newValues += temp[1];
        }
    }
