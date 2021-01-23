        function pmValidateGLAccount(oSrc, args) {
        var GLIsValid;
        args.IsValid =false;
        PageMethods.ValidateGLAccountAccess(args.Value, OnSuccess);
        function OnSuccess(result) {            
            if (args.Value != result) {
                GLIsValid = false; // or you don't need this
                args.IsValid= false;
                alert(args.IsValid);
            }
            else {
                GLIsValid = false; // or you don't need this
                args.IsValid= true;
                alert(args.IsValid);
            }
        } 
    
    } 
