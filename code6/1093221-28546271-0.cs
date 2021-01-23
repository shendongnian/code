    namespace smallTesting
    {
        class Testing
        {
            public Testing(Form1 currentInstance)
            {
                MessageBox.Show("Connection String Did not found");
                int i = 1;
                while(i < 50)
                {
                    currentInstance.renderMessage(i.ToString());               
                    i++;
                }
            }
        }
    }
