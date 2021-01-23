    public void showListControl(ListControl lstcontrol)
    {
            lstcontrol.ID = "ControlID_3";
            SqlDataReader dr_answer = cmd.ExecuteReader();
            while (dr_answer.Read())
            {
                lstcontrol.Items.Add(dr_answer["answer"].ToString());
            }
    }
