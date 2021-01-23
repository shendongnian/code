        You cannot use Regular Expressions for validating dates. 
    Instead you can use something like this : 
        
        
        **HTML :**
            
            <input type="date" id="dob" name="dob" runat="server" />
            <input type="date" id="joinDate" name="jDate" runat="server" />
            
        **C# Code :**
            
            protected Boolean Validate_DateOfBirth()
                    {
                        int dateDOB, joiningDt;
                        string joiningDate = joinDate.Value; ;
                        string varDOB = dob.Value;
                        varDOB = varDOB.Replace(@"-", "");//Our string will be in yyyyMMdd format now.
                        joiningDate = joiningDate.Replace(@"-", "");
            
                        dateDOB=int.Parse(varDOB);
                        joiningDt = int.Parse(joiningDate);
                        if (dateDOB > joiningDt){
                            //Raise your error here. 
                            return false;
                        }
                        else{
                            //Everything id fine..
                            return true;
                        }
                    }
        
        You can implement the similar thing for comparing date of joining and 
    date of leaving..
