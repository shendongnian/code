    /* Add this reference */
    
    using System.Text.RegularExpressions;
    
    ---------------------------
    string UserMessage = string.Empty;
    
    if (!string.IsNullOrWhiteSpace(txtEmail.Text))
    {
        Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        if (!reg.IsMatch(txtEmail.Text))
        {
            UserMessage += "* Email is not valid. \n\n";
            isValid = false;
        }
    }
