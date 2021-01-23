    MyCheckboxes.SearchProperties[HtmlCheckBox.PropertyNames.Type] = "checkbox";
    UITestControlCollection CheckboxCollection = MyCheckboxes.FindMatchingControls();
    IEnumerator<UITestControl> CheckboxEnum = CheckboxCollection .GetEnumerator();
    int randomNum = new Random().Next(1, CheckboxCollection.Count );   
    
    for(int i = 0; i!=randomNum; i++)
    {
        CheckboxEnum.MoveNext();       
    }
    Mouse.Click(CheckboxEnum.Current)
