    var theButton = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
    if(someCondition)
    {
        theButton.IsEnabled = true;
    }
    else
    {
        theButton.IsEnabled = false;
    }
    //or shorter:
    theButton.IsEnabled = someCondition
