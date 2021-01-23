    public static String Concat(String str0, String str1) {
        Contract.Ensures(Contract.Result() != null);
        Contract.Ensures(Contract.Result().Length ==
            (str0 == null ? 0 : str0.Length) + 
            (str1 == null ? 0 : str1.Length));
        Contract.EndContractBlock(); 
 
        // ========= OPTIMIZATION BEGINS ===============
        if (IsNullOrEmpty(str0)) {
            if (IsNullOrEmpty(str1)) { 
                return String.Empty;
            }
            return str1;
        } 
        if (IsNullOrEmpty(str1)) { 
            return str0; 
        }
        // ========== OPTIMIZATION ENDS =============
 
        int str0Length = str0.Length;
        String result = FastAllocateString(str0Length + str1.Length);
 
        FillStringChecked(result, 0,        str0);
        FillStringChecked(result, str0Length, str1); 
 
        return result;
    }
