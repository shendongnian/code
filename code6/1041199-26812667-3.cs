    string state1 = State.Text;
    for (int i = 0; i < stateList.Count; i++)
    {
        if (state1.Equals(stateList[i]))
        {
            Response.Write("The " + stateList[i] + " state GDP is " + gdpList[i] + " and the rank is " + rankList[i]);
            return;
        }
    }
    Response.Write("The state that you entered is not a part of our state list");
