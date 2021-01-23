    bool Function()
    {
        for(int i = 0; i < 10; ++i)
        {
            for(int j = 0; j < 10; ++j)
            {
                if (error)
                {
                    MessageBox.Show("THE ITEM ID DOES NOT EXIST.!");
                    return false;
                }
            }
        }
        return true;
    }
