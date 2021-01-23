    var stateList = new List<string>
    {
     "Delaware",
     "Alaska",
     "North Dakota",
     "Connecticut",
     "Wyoming",
     "Massachusetts",
     "New York",
     "New Jersey",
     "Oregon",
     "Washington",
     "Virginia",
     "Minnesota"
    };
    
    var rankList = new List<int>
    {
        1,2,3,4,5,6,7,8,9,10,11,12
    };
    
    var gdpList = new List<string>
    {
        "61,183",
        "61,156",
        "55,250",
        "54,925",
        "54,305",
        "53,221",
        "53,067",
        "49,430",
        "48,069",
        "47,146",
        "47,127",
        "47,028"
    };
    
    string state1 = State.Text;
    for (int i = 0; i < stateList.Count; i++)
    {
        if (state1.Contains(stateList[i]))
        {
            Response.Write(string.Format("The {0} state GDP is {1} and the rank is {2} " ,stateList[i], gdpList[i], rankList[i]));
        }
        else if (!state1.Contains(stateList[i]))
        {
            Response.Write("The state that you entered is not a part of our state list");
            return;
        }
    }
