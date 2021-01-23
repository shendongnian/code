    for (int i = 0; i< ListBox1.Items.Length; i++)
    {
        if (ListBox1.Items[i].Selected)
        {
            i = i + 1;
    
            //Run at 20 to speed up query
            if (i == 20)
            {
                //Get data
                CustList.AddRange(BL.SearchCustomerByPostcodeArea(postcodecollection,2));
                i = 0;
                }
                else
                {
                    //add the post code to temp list
                    postcodecollection.Add(ListBox1.DataSource.ToList().ElementAt(i));
                }
            }
        }
    
        if (i > 0)
        {
            //get data
            CustList.AddRange(BL.SearchCustomerByPostcodeArea(postcodecollection,2));
        }
    }
