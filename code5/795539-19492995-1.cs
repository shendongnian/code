    protected void ibtn_save_detail_Click(object sender, ImageClickEventArgs e)
    {
        Fill_Form();
        RewardDetails obj = new RewardDetails();
        var collection = ddl_employees.CheckedItems;
        for (int i = 0; i < collection.Count; i++)
        {
            obj.Emp_num = int.Parse(collection[i].Value);
            ...
            
            string res;
            try
            {
                res = obj.InsertReward();
                // stuff to do if added
            }
            catch (RewardExistsException)
            {
                // stuff to do if already exists
            }
        }
    }
