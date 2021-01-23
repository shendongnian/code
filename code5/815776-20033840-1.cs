    bool IsBinaryNumber(string test){
            foreach(char c in test){
                // If c is not either 0 or 1, break.
                if(!((c=='0') || (c== '1'))){
                    return false;
                }
            }
            // If everything went well, it's a binary number.
            return true;
     }
