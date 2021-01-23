        for (int i = 0; i < firstList.Count; i++) {
            // Checks for nulls.
            if(firstList[i] == null){
                _firstList.Add("null");
            }
            else {
                _firstList.Add(firstList[i].ToString());
            } 
            if (secondList[i] == null){
                _secondList.Add("null");
            }
            else{
                _secondList.Add(secondList[i].ToString());
            }
        }
