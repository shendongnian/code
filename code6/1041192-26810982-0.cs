    void GDP_Click(object sender, EventArgs e)
    {
        string  state1 = State.Text;
        bool foundMatch = false;
        for (int i = 0; i < stateList.Count; i++ )
        {
            if (state1 == stateList[i])
            {
                Response.Write("The " + stateList[i] + " state GDP is " + gdpList[i] + " and the rank is " + rankList[i]);
                foundMatch = true;
                break;
            }
        }
    
        if (!foundMatch)
        {
            Response.Write("The state that you entered is not a part of our state list");
        }
    }
