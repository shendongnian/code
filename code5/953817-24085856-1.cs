    switch (param.Component.Type)
        {
            case "Combo":
                returnComboItemSelect = generateCB(param);
                 if(returnComboItemSelect=="Slider")
                 {
                   returnSomething  = generateSl(param,returnComboItemSelect); //I mean no need to jump
                 }
                break;                            
            case "List":
                returnSomething = generateL(param);
                break;
            case "Slider":
                returnSomething 
    .....
