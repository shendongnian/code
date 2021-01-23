    private List<DropDownList> MyDropDownLists { get; set; }
    // the page constructor
    public MyPage()
    {
        MyDropDownLists.Add(dropDownList1);
        MyDropDownLists.Add(dropDownList2);
        MyDropDownLists.Add(dropDownList3);
        MyDropDownLists.Add(dropDownList4);
        // etc...
        // You might even extract all of this into a CollectDropDownLists function
    }
