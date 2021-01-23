    protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvActList.Rows.Count > 0)
            {
                foreach (GridViewRow row in gvActList.Rows)
                {
                    RadioButton rdYes= (RadioButton)row.FindControl("rdYes");
                    RadioButton rdNo = (RadioButton)row.FindControl("rdNo");
                    RadioButton rdNone = (RadioButton)row.FindControl("rdNone");
                    if (rdYes != null && rdNo != null && rdNone != null)
                    {
                        if (rdYes.Checked == true)
                        {
                            //some code
                        }
                        else if (rdNo.Checked == true)
                        {
                            //some code
                        }
                    }
                }
            }
        }
