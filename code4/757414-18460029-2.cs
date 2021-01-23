     .... inside ILNumerics function
     using (ILScope.Enter(inparameter1,inparameter2)) {
        ....
        ILArray<double> A = zeros(1000,1000);  // allocate memory for external use
        var aArray = A.GetArrayForWrite();     // fetch reference to underlying System.Array  
        callOtherLib(aArray);                  // let other lib use and fill the array
        // proceed normally with A... 
        return A + 1 * 2 ... ; 
     }
