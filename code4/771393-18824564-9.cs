        string ErrorMessage;
        int result = DoSomthing(1, 2, out ErrorMessage);
        if (!String.IsNullOrEmpty(ErrorMessage))
        {
            MessageBox.Show(ErrorMessage);
        }
