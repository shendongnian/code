        if (string.IsNullOrWhiteSpace(Convert.ToString(postedFormData["UserName"])))
            {
                LoginViewModel.ReturnMessage.Clear();
                LoginViewModel.ReturnMessage.Add("Enter Username");
                LoginViewModel.ReturnStatus = false;
            }
         else if (string.IsNullOrWhiteSpace(Convert.ToString(postedFormData["Password"])))
            {
                LoginViewModel.ReturnMessage.Clear();
                LoginViewModel.ReturnMessage.Add("Enter Password");
                LoginViewModel.ReturnStatus = false;
            }
