        String localVar = Convert.ToString(Dts.Variables["User::Variable"].Value);
        if (!String.IsNullOrEmpty(localVar))
        {
            MessageBox.Show(Dts.Variables["User::Variable"].Value.ToString());
        }
