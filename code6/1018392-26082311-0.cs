    for (int i = 0; i < cblCandidateName1.Items.Count; i++)
    {
        if (cblCandidateName1.Items[i].Selected ==true)
        {
            strcbl1 = strcbl1 + cblCandidateName1.Items[i].Value.ToString() + ",";
        }
    }
    for (int j = 0; j < cblPayment1.Items.Count; j++)
    {
        if (cblPayment1.Items[j].Selected == true)
        {
            strcbl2 += cblPayment1.Items[j].Value.ToString() + ",";
        }
    }
