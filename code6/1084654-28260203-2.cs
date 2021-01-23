    for (int k = 0; k < MyList.Count; k++)
    {
         MyDB_Tables Model_T = new MyDB_Tables();
         Model_T.ID = MyList[k].ID;
         Model_T.GroupNumber = MyList[k].GroupNumber;
         Model_T.ModelName = MyList[k].ModelName;
         Model_T.Picture = MyList[k].Picture;
         ArrList.Add(Model_T);
    }
